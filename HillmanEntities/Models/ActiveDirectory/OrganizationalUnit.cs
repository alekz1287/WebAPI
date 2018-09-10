using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.ActiveDirectory
{
    /// <summary>
    /// Represents an Organizational Unit as it appears in Active Directory
    /// </summary>
    public class OrganizationalUnit
    {
        public string NAME { get; set; }

        public OrganizationalUnit()
        {

        }

        public OrganizationalUnit(LdapEntry entry)
        {
            PropertyInfo[] props = typeof(OrganizationalUnit).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (entry.getAttribute(prop.Name) != null)
                {
                    prop.SetValue(this, entry.getAttribute(prop.Name).StringValue);
                }
            }
        }
    }
}
