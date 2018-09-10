using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.Concur;
using HillmanGroup.API.Models.Concur.FTP;
using HillmanMVC2.Services;
using Microsoft.AspNetCore.Mvc;
using HillmanMVC2.Services.Interfaces;

namespace HillmanMVC2.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ConcurController : Controller
    {
        private IConcurClient _implementation;

        public ConcurController(IConcurClient client)
        {
            _implementation = client;
        }

        [HttpPost("api/Concur/Employees")]
        public System.Threading.Tasks.Task ImportEmployees([FromBody] ConcurImportDataFile ftpFile)
        {
            return _implementation.ImportEmployeesAsync(ftpFile);
        }

        [HttpGet("api/Concur/StandardAccountingExtracts")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<StandardAccountingExtract>> GetStandardAccountingExtracts()
        {
            return _implementation.GetStandardAccountingExtractsAsync();
        }

        [HttpGet("api/Concur/GetEditionType")]
        public System.Threading.Tasks.Task<string> GetEditionType()
        {
            return _implementation.GetEditionTypeAsync();
        }
    }
}