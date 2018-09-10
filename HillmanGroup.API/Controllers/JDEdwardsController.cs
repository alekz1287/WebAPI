using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Novell.Directory.Ldap;
using HillmanGroup.API.Models.Concur;
using HillmanGroup.API.Models.Shared;
using HillmanGroup.API.Models.Concur.FTP;

namespace HillmanGroup.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class JDEdwardsController : Controller
    {
        private Services.IJDEdwardsRepository _jdeRepository;

        public JDEdwardsController(Services.IJDEdwardsRepository jdeRepository)
        {
            _jdeRepository = jdeRepository;
        }
        
        /// <summary>
        /// Retrieves employees from JDEdwards. 
        /// </summary>
        /// <param name="numberOfRows">The number of records to return. Negative numbers return all records.</param>
        /// <returns></returns>
        [HttpGet("Employees/{numberOfRows}")]
        [ProducesResponseType(typeof(ICollection<Employee>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetEmployeesCount(int numberOfRows = -1)
        {
            try
            {
                return Ok(_jdeRepository.GetEmployees(numberOfRows));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Inserts transactions into the Enterprises One zTable
        /// </summary>
        /// <param name="saes"></param>
        /// <returns></returns>
        [HttpPost("VoucherTransactions")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult InsertExpenseData([FromBody] ICollection<StandardAccountingExtract> saes)
        {
            try
            {
                _jdeRepository.InsertTransactions(saes);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

