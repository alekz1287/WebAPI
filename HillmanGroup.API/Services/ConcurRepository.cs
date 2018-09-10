using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Validation;
using HillmanGroup.API.Services;
using Microsoft.Extensions.Configuration;
using HillmanGroup.API.Models.Concur;
using FluentValidation.Results;
using SimpleImpersonation;
using HillmanGroup.API.Models.Concur.FTP;
using System.IO;

namespace HillmanGroup.API.Services
{


    public class ConcurRepository : IConcurRepository
    {
        //const string BaseUrl = "https://www.concursolutions.com/api";
        private readonly string _entityId;
        private readonly string _outboundDirectory;
        private readonly string _inboundDirectory;
        private readonly string _receivedDirectory;
        private readonly string _vlTraderUserName;
        private readonly string _vlTraderPassword;


        public ConcurRepository(string entityId, string outboundDirectory,
            string inboundDirectory, string receivedDirectory, string vlTraderUserName, string vlTraderPassword)
        {
            _entityId = entityId;
            _outboundDirectory = outboundDirectory;
            _inboundDirectory = inboundDirectory;
            _receivedDirectory = receivedDirectory;
            _vlTraderUserName = vlTraderUserName;
            _vlTraderPassword = vlTraderPassword;
        }

        /// <summary>
        /// Not until we have an API Key :(
        /// </summary>
        /// <returns></returns>
        public bool CreateOrUpdateUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not until we have an API Key :(
        /// </summary>
        /// <returns></returns>
        public string GetEditionType()
        {
            throw new NotImplementedException();
        }

        /// <summary>S
        /// Creates a properly formatted employee import file and places it in the given directory
        /// </summary>
        /// <param name="file"></param>
        /// <param name="directory"></param>
        /// <param name="concurEntityId"></param>
        /// <returns>True if successful</returns>
        public bool SendFtpFileToOutgoingDirectory(ConcurImportDataFile file)
        {
            ValidationResult result = file.Validate();

            if (result.IsValid)
            {
                var credentials = new UserCredentials(_vlTraderUserName, _vlTraderPassword);

                Impersonation.RunAsUser(credentials, LogonType.NewCredentials, () =>
                {
                        //employee_t0001234uv1w_sample_20051206095621.txt.pgp 
                        string fileName = "employee_" + _entityId + "_sample_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                    System.IO.File.WriteAllText(_outboundDirectory + "\\" + fileName, file.Serialize(), System.Text.Encoding.UTF8);
                });

                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieves all Standard Accounting Extracts that we can find in the "inbound" folder
        /// </summary>
        /// <returns></returns>
        public List<StandardAccountingExtract> GetStandardAccountingExtracts()
        {
            List<StandardAccountingExtract> saes = new List<StandardAccountingExtract>();
            var credentials = new UserCredentials(_vlTraderUserName, _vlTraderPassword);
            Impersonation.RunAsUser(credentials, LogonType.NewCredentials, () =>
            {
                //Read through the files in this directory
                foreach (string file in Directory.EnumerateFiles(_inboundDirectory, "*.xlsx"))
                {
                    //Read each file into an object
                    StandardAccountingExtract sae = new StandardAccountingExtract(file);
                    saes.Add(sae);
                }
            });

            return saes;
        }

        /// <summary>
        /// Once we've processed a Standard Accounting Extract, that file should be moved
        /// from the "inbound" folder to the "received" folder.
        /// That way we know it's been processed but still have a copy for record keeping
        /// </summary>
        /// <param name="saes"></param>
        public void RelocateStandardAccountingExtract(ICollection<StandardAccountingExtract> saes)
        {
            var credentials = new UserCredentials(_vlTraderUserName, _vlTraderPassword);
            Impersonation.RunAsUser(credentials, LogonType.NewCredentials, () =>
            {
                foreach(StandardAccountingExtract sae in saes)
                {
                    string sourceFile = sae.FilePath;
                    string destFile = Path.Combine(_receivedDirectory, Path.GetFileName(sourceFile));
                    File.Move(sourceFile, destFile);
                }
            });
        }
    }

}
