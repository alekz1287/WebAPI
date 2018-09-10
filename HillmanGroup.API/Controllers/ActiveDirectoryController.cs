using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.ActiveDirectory;
using Microsoft.AspNetCore.Mvc;
using Novell.Directory.Ldap;

namespace HillmanGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveDirectoryController : Controller
    {
        private Services.IActiveDirectoryService _activeDirectoryService;
        
        public ActiveDirectoryController(Services.IActiveDirectoryService  activeDirectoryService)
        {
            _activeDirectoryService = activeDirectoryService;
        }

        /// <summary>
        /// Get an employee from AD using their email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpGet("Employee/{emailAddress}")]
        [ProducesResponseType(typeof(ActiveDirectoryUser), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetEmployeeByEmail(string emailAddress)
        {
            try
            {
                ActiveDirectoryUser entry = _activeDirectoryService.GetEmployeeByEmail(emailAddress);

                return Ok(entry);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all employees for US and CAN from Active Directory
        /// </summary>
        /// <returns></returns>
        [HttpGet("Employees")]
        [ProducesResponseType(typeof(ICollection<ActiveDirectoryUser>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetEmployeesFromLDAP()
        {
            try
            {
                ICollection<ActiveDirectoryUser> entries = _activeDirectoryService.GetEmployees();

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all employees from a given search base in Active Directory
        /// </summary>
        /// <param name="searchBase"></param>
        /// <returns></returns>
        [HttpGet("Employees/{searchBase}")]
        [ProducesResponseType(typeof(ICollection<ActiveDirectoryUser>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetEmployeesFromLDAP(string searchBase)
        {
            try
            {
                ICollection<ActiveDirectoryUser> entries = _activeDirectoryService.GetEmployees(searchBase, "(objectclass=user)");

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Organizations from US and CAN from from Active Directory
        /// </summary>
        /// <returns></returns>
        [HttpGet("Organizations")]
        [ProducesResponseType(typeof(ICollection<OrganizationalUnit>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetOrganizations()
        {
            try
            {
                ICollection<OrganizationalUnit> entries = _activeDirectoryService.GetAllOrganizations();

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Organizations from a given search base in Active Directory
        /// </summary>
        /// <param name="searchBase"></param>
        /// <returns></returns>
        [HttpGet("Organizations/{searchBase}")]
        [ProducesResponseType(typeof(ICollection<OrganizationalUnit>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetOrganizations(string searchBase)
        {
            try
            {
                ICollection<OrganizationalUnit> entries = _activeDirectoryService.GetAllOrganizations(searchBase);

                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}