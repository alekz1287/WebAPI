using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur
{
    /// <summary>
    /// Used for marking the properties in the Concur models that need to be included in the FTP upload
    /// INDEXES START AT 111ONE111 BECAUSE CONCUR AND EXCEL AND CLOSEDXML COUNT FROM 1!
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class FtpFieldAttribute : Attribute
    {
        public int PositionIndex { get; set; }

        public FtpFieldAttribute(int positionIndex)
        {
            PositionIndex = positionIndex;
        }
    }
}
