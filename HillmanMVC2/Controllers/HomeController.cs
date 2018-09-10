using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HillmanMVC2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using HillmanGroup.API.Models.ActiveDirectory;
using Newtonsoft.Json;
using HillmanMVC2.Services.Interfaces;

namespace HillmanMVC2.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {
        private IActiveDirectoryClient _client;

        public HomeController(IActiveDirectoryClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            Models.ViewModels.HomeViewModel vm = new Models.ViewModels.HomeViewModel();
            var userEmail = User.Identity.Name;

#if DEBUG
            userEmail = "akellerman@hillmangroup.com";
#endif

            //Get a list of organizations
            var organizations = _client.GetOrganizationsAllAsync().Result;
            vm.OrganizationOptions = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(organizations, "NAME", "NAME");

            //Which one do I belong to?
            var currentUser = _client.GetEmployeeByEmailAsync(userEmail).Result;
            if (currentUser != null)
            {
                vm.SelectedOrganization = currentUser.organizationalUnit;

                //Get the employees that also belong to this organization
                //vm.EmployeeData = JsonConvert.SerializeObject(GetEmployeesByOrganization(currentUser.organizationalUnit));
            }

            return View(vm);
        }

        public IActionResult Swagger()
        {
            return View();
        }

        [HttpGet("GetEmployeesByOrganization/{organizationalUnit}")]
        public JsonResult GetEmployeesByOrganization(string organizationalUnit)
        {
            return Json(_client.GetEmployeesFromLDAPAsync($"OU={organizationalUnit},OU=US,OU=Users,OU=All,DC=hillmangroup,DC=com").Result);
        }
    }
}
