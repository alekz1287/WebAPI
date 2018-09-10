using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using HillmanGroup.API.Models.Concur;
using HillmanGroup.API.Models.Concur.FTP;
using HillmanGroup.API.Models.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HillmanGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : Controller
    {
        private Services.IJDEdwardsRepository _jdeRepository;
        private Services.IConcurRepository _concurRepository;
        private Services.IActiveDirectoryService _activeDirectoryService;

        public IntegrationController(Services.IJDEdwardsRepository jdeRepository,
            Services.IConcurRepository concurRepository,
            Services.IActiveDirectoryService activeDirectoryService)
        {
            _jdeRepository = jdeRepository;
            _concurRepository = concurRepository;
            _activeDirectoryService = activeDirectoryService;
        }

        /// <summary>
        /// Retrieves the employee records from ActiveDirectory and JDEdwards
        /// Combines them into an FTP document
        /// Places that document into a folder that VL Trader will then upload to Concur
        /// </summary>
        /// <returns></returns>
        [HttpGet("SendEmployeesFromEnterpriseOneToConcur")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult SendEmployeesToConcur()
        {
            try
            {
                //Get the employee data from both sources
                var jdeEmployees = _jdeRepository.GetEmployees();
                var adEmployees = _activeDirectoryService.GetEmployees();

                //use the active directory data to complete the employee data we get from JDE
                int matchCounter = 0;
                List<Employee> unmatchedEmployees = new List<Employee>();
                foreach (Employee emp in jdeEmployees)
                {
                    //Find the match in adEmployees
                    var adRecord = adEmployees.Where(ad => ad.sAMAccountName == emp.Employee_ID.ToLower()).FirstOrDefault();
                    if (adRecord != null)
                    {
                        emp.Email_Address = adRecord.mail;
                        emp.Login_ID = adRecord.mail;
                        matchCounter++;
                    }
                    else
                    {
                        unmatchedEmployees.Add(emp);
                    }
                }

                //If we couldn't find AD data for an employee, remove them from the upload
                List<Employee> matchedEmployees = jdeEmployees.Except(unmatchedEmployees).ToList();

                //Package that data into a file
                ConcurImportDataFile ftpFile = new ConcurImportDataFile(new _305_EnhancedEmployeeSection(matchedEmployees));

                //Send that file to the outgoing directory where it will be picked up and sent to concur
                if (_concurRepository.SendFtpFileToOutgoingDirectory(ftpFile))
                {
                    return NoContent();
                }
                else
                {
                    //If we failed to create the file, report why
                    ValidationResult result = ftpFile.Validate();
                    return StatusCode(500, result.Errors.ToList().ToString());
                }
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Checks the INBOUND Concur folder for Standard Accounting Extracts
        /// Any extracts found are then parsed and entered into JDEdwards
        /// </summary>
        /// <returns></returns>
        [HttpGet("LoadExpenseDataFromConcurToEnterpriseOne")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetExpenseDataFromConcur()
        {
            try
            {
                //Get the Standard Accounting Extracts from the Concur Inbound folder
                List<StandardAccountingExtract> saes = _concurRepository.GetStandardAccountingExtracts();

                //Map these extracts to JDE F0411z1 object and update the database
                _jdeRepository.InsertTransactions(saes);

                //Move the processed extracts to a different folder so that we don't process them again
                _concurRepository.RelocateStandardAccountingExtract(saes);

                return NoContent();
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}