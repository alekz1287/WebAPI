using Microsoft.Extensions.Configuration;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.ActiveDirectory;

namespace HillmanGroup.API.Services
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        private readonly string _activeDirectoryHostName;
        private readonly int _activeDirectoryHostPort;
        private readonly string _activeDirectoryUserName;
        private readonly string _activeDirectoryPassword;

        public ActiveDirectoryService(IConfiguration config)
        {
            _activeDirectoryHostName = config["ActiveDirectory:HostName"];
            Int32.TryParse(config["ActiveDirectory:HostPort"], out _activeDirectoryHostPort);
            _activeDirectoryUserName = config["ActiveDirectory:UserName"];
            _activeDirectoryPassword = config["ActiveDirectory:Password"];

        }

        private LdapConnection GetConnection()
        {
            LdapConnection _connection = new LdapConnection();
            try
            {

                _connection.Connect(_activeDirectoryHostName, _activeDirectoryHostPort);
                _connection.Bind(LdapConnection.Ldap_V3, _activeDirectoryUserName, _activeDirectoryPassword);
            }
            catch (Exception e)
            {
                throw new Exception("There was an error connecting to Active Directory."
                    + "Verify that you are on the Hillman network and have provided the correct credentials.", e.InnerException);
            }
            return _connection;
        }

        public ActiveDirectoryUser GetEmployeeByEmail(string emailAddress)
        {
            return GetEmployees("OU=Users,OU=All,DC=hillmangroup,DC=com", $"(mail={emailAddress})").FirstOrDefault();
        }
     
        /// <summary>
        /// Queries Active Directory for all employees in the US and Canada
        /// </summary>
        /// <returns></returns>
        public ICollection<ActiveDirectoryUser> GetEmployees()
        {
            //string searchBase = "OU=Users,OU=All,DC=hillmangroup,DC=com";
            //return GetEmployeesAsync(searchBase);

            return GetEmployees("OU=US,OU=Users,OU=All,DC=hillmangroup,DC=com", "(objectclass=user)")
               .Concat(GetEmployees("OU=CA,OU=Users,OU=All,DC=hillmangroup,DC=com", "(objectclass=user)")).ToList();
        }

        /// <summary>
        /// Queries Active Directory for all employees in the US
        /// </summary>
        /// <param name="LDAP_ATTRS"></param>
        /// <returns></returns>
        public ICollection<ActiveDirectoryUser> GetEmployees(string searchBase, string searchFilter)
        {
            String[] LDAP_ATTRS = { "sAMAccountName", "mail", "employeeID", "description", "givenName", "sn", "company", "department", "displayName", "distinguishedName" };
            List<ActiveDirectoryUser> matchingEntries = new List<ActiveDirectoryUser>();

            // Creating an LdapConnection instance 
            LdapConnection ldapConn = GetConnection();
            //String searchBase = "OU=Users,OU=All,DC=hillmangroup,DC=com";
            //String searchFilter = "(objectclass=user)";

            //Do not limit us to 1000 records
            LdapSearchConstraints constraints = new LdapSearchConstraints();
            constraints.MaxResults = 0;

            LdapSearchQueue queue =
                ldapConn.Search(searchBase,
                                LdapConnection.SCOPE_SUB,
                                searchFilter,
                                LDAP_ATTRS,
                                false,
                                (LdapSearchQueue)null,
                                constraints);
            LdapMessage message;

            while ((message = queue.getResponse()) != null)
            {
                if (message is LdapSearchResult)
                {
                    LdapEntry entry = ((LdapSearchResult)message).Entry;
                    matchingEntries.Add(new ActiveDirectoryUser(entry));
                }
            }

            //While all the required entries are parsed, disconnect   
            ldapConn.Disconnect();

            return matchingEntries;
        }

        /// <summary>
        /// Retrieves all organizations from US and Canada
        /// </summary>
        /// <returns></returns>
        public ICollection<OrganizationalUnit> GetAllOrganizations()
        {
            
            return GetAllOrganizations("OU=US,OU=Users,OU=All,DC=hillmangroup,DC=com")
                .Concat(GetAllOrganizations("OU=CA,OU=Users,OU=All,DC=hillmangroup,DC=com")).ToList();
        }

        public ICollection<OrganizationalUnit> GetAllOrganizations(string searchBase)
        {
            var groups = new List<OrganizationalUnit>();

            // Creating an LdapConnection instance 
            LdapConnection ldapConn = GetConnection();
            String searchFilter = "(objectCategory=organizationalUnit)";

            //Do not limit us to 1000 records
            LdapSearchConstraints constraints = new LdapSearchConstraints();
            constraints.MaxResults = 0;

            LdapSearchQueue queue =
                ldapConn.Search(searchBase,
                                LdapConnection.SCOPE_ONE,
                                searchFilter,
                                null,
                                false,
                                (LdapSearchQueue)null,
                                constraints);
            LdapMessage message;

            while ((message = queue.getResponse()) != null)
            {
                if (message is LdapSearchResult)
                {
                    LdapEntry entry = ((LdapSearchResult)message).Entry;

                    groups.Add(new OrganizationalUnit(entry));
                }
            }

            //While all the required entries are parsed, disconnect   
            ldapConn.Disconnect();

            return groups;
        }
    }
}
