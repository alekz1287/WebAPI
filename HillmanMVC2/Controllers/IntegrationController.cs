using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanMVC2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HillmanMVC2.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class IntegrationController : Controller
    {
        private IIntegrationClient _implementation;

        public IntegrationController(IIntegrationClient implementation)
        {
            _implementation = implementation;
        }

        [HttpGet("api/Integration/SendEmployeesFromEnterpriseOneToConcur")]
        public System.Threading.Tasks.Task SendEmployeesToConcur()
        {
            return _implementation.SendEmployeesToConcurAsync();
        }

        [HttpGet("api/Integration/LoadExpenseDataFromConcurToEnterpriseOne")]
        public System.Threading.Tasks.Task GetExpenseDataFromConcur()
        {
            return _implementation.GetExpenseDataFromConcurAsync();
        }
    }
}