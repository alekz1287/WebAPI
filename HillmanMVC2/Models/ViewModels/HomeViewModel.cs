using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanMVC2.Models.ViewModels
{
    public class HomeViewModel
    {
        public SelectList OrganizationOptions { get; set; }
        public string SelectedOrganization { get; set; }
        public string EmployeeData { get; set; }
    }
}
