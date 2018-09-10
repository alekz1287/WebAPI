using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur
{
    public class Helpers
    {
        /// <summary>
        /// Concur's import file specification includes many unused fields.
        /// Rather than include all of these fields as properties in our class, we only include the fields we use.
        /// We then number those fields according to the index at which they should appear in the comma-separated list of values
        /// that we upload to concur.
        /// This function matches properties to indexes using the custom ConcurFtpFieldAttribute
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, PropertyInfo> GetFtpFieldIndexes<T>()
        {
            Dictionary<int, PropertyInfo> _dict = new Dictionary<int, PropertyInfo>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                IEnumerable<Attribute> attrs = prop.GetCustomAttributes();
                foreach (object attr in attrs)
                {
                    FtpFieldAttribute ftpAttr = attr as FtpFieldAttribute;
                    if (ftpAttr != null)
                    {
                        string propName = prop.Name;
                        int index = ftpAttr.PositionIndex;

                        _dict.Add(index, prop);
                    }
                }
            }

            return _dict;
        }

        /// <summary>
        /// Returns the excel column name that matches the given column index. Ex: 1 = A, 26 = 7, 28 = AB
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}
