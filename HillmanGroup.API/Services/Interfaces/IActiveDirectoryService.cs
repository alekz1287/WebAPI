using HillmanGroup.API.Models.ActiveDirectory;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Services
{
    public interface IActiveDirectoryService
    {
        ActiveDirectoryUser GetEmployeeByEmail(string emailAddress);

        ICollection<ActiveDirectoryUser> GetEmployees(string searchBase, string searchFilter);
        
        ICollection<ActiveDirectoryUser> GetEmployees();

        ICollection<OrganizationalUnit> GetAllOrganizations();

        ICollection<OrganizationalUnit> GetAllOrganizations(string searchBase);
    }
}
