using HillmanGroup.API.Models.Concur;
using HillmanGroup.API.Models.Concur.FTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Services
{
    public interface IConcurRepository
    {
        bool CreateOrUpdateUser();

        string GetEditionType();

        bool SendFtpFileToOutgoingDirectory(ConcurImportDataFile file);

        List<StandardAccountingExtract> GetStandardAccountingExtracts();

        void RelocateStandardAccountingExtract(ICollection<StandardAccountingExtract> saes);
    }
}
