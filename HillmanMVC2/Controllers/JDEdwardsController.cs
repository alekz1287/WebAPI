using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.Concur.FTP;
using HillmanGroup.API.Models.Shared;
using HillmanMVC2.Services;
using HillmanMVC2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HillmanMVC2.Controllers
{

    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class JDEdwardsController : Controller
    {

        private IJDEdwardsClient _implementation;

        public JDEdwardsController(IJDEdwardsClient client)
        {
            _implementation = client;
        }

        [HttpGet("api/JDEdwards/Employees/{numberOfRows}")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Employee>> GetEmployeesCount(int numberOfRows)
        {
            return _implementation.GetEmployeesCountAsync(numberOfRows);
        }

        [HttpPost("api/JDEdwards/VoucherTransactions")]
        public System.Threading.Tasks.Task InsertExpenseData([FromBody] IEnumerable<StandardAccountingExtract> saes)
        {
            return _implementation.InsertExpenseDataAsync(saes);
        }

    }
}