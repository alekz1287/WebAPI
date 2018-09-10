using Novell.Directory.Ldap;
using System.Reflection;
using Newtonsoft.Json;

namespace HillmanGroup.API.Models.ActiveDirectory
{
    /// <summary>
    /// Represents a user record as it appears in Active Directory
    /// </summary>
    public class ActiveDirectoryUser
    {
        //private String[] LDAP_ATTRS = { "company", "department", "displayName", "mail", "sAMAccountName", "employeeID", "description", "givenName", "sn" };

        public string company { get; set; }
        public string department { get; set; }
        public string displayName { get; set; }
        public string mail { get; set; }
        public string sAMAccountName { get; set; }
        public string employeeID { get; set; }
        public string description { get; set; }
        public string givenName { get; set; }
        public string sn { get; set; }
        public string distinguishedName { get; set; }

        /// <summary>
        /// Active Directory nodes are read from RIGHT TO LEFT. 
        /// We want to know the most specific Organizational Unit (OU) for this user
        /// </summary>
        public string organizationalUnit {
            get
            {
                
                //CN=Brian Krahenbuhl,OU=Hamilton,OU=US,OU=Users,OU=All,DC=hillmangroup,DC=com
                string[] adNodes = distinguishedName.Split(",");
                foreach(string node in adNodes)
                {
                    if (node.Contains("OU="))
                    {
                        return node.Substring(3);
                    }
                }

                return null;
            }
        }

        public ActiveDirectoryUser()
        {

        }

        public ActiveDirectoryUser(LdapEntry entry)
        {
            PropertyInfo[] props = typeof(ActiveDirectoryUser).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if(entry.getAttribute(prop.Name) != null)
                {
                    prop.SetValue(this, entry.getAttribute(prop.Name).StringValue);
                }
            }
        }

        public override string ToString()
        {            
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
