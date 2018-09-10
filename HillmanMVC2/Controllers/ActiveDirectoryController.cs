using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.ActiveDirectory;
using Microsoft.AspNetCore.Mvc;
using HillmanMVC2.Services.Interfaces;

namespace HillmanMVC2.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ActiveDirectoryController : Controller
    {
        private IActiveDirectoryClient _implementation;

        public ActiveDirectoryController(IActiveDirectoryClient client)
        {
            _implementation = client;
        }

        [HttpGet("api/ActiveDirectory/Employee/{emailAddress}")]
        public System.Threading.Tasks.Task<ActiveDirectoryUser> GetEmployeeByEmail(string emailAddress)
        {
            return _implementation.GetEmployeeByEmailAsync(emailAddress);
        }

        [HttpGet("api/ActiveDirectory/Employees")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ActiveDirectoryUser>> GetEmployeesFromLDAPAll()
        {
            return _implementation.GetEmployeesFromLDAPAllAsync();
        }

        [HttpGet("api/ActiveDirectory/Employees/{searchBase}")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ActiveDirectoryUser>> GetEmployeesFromLDAP(string searchBase)
        {
            return _implementation.GetEmployeesFromLDAPAsync(searchBase);
        }

        [HttpGet("api/ActiveDirectory/Organizations")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<OrganizationalUnit>> GetOrganizationsAll()
        {
            return _implementation.GetOrganizationsAllAsync();
        }

        [HttpGet("api/ActiveDirectory/Organizations/{searchBase}")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<OrganizationalUnit>> GetOrganizations(string searchBase)
        {
            return _implementation.GetOrganizationsAsync(searchBase);
        }
    }
}