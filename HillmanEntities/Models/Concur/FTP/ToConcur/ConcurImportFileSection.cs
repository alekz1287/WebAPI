using FluentValidation.Results;
using HillmanGroup.API.Models.Concur;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur
{
    /// <summary>
    /// Base class for sections of any "Import/Upload" document
    /// Provides shared "Serialize" functionality and enforces Validate() requirement
    /// </summary>
    public abstract class ConcurImportFileSection
    {
        public ConcurImportFileSection(string transaction_Type, int number_Of_Columns)
        {
            Transaction_Type = transaction_Type;
            Number_Of_Columns = number_Of_Columns;
            FieldSeparator = ",";
        }

        /// <summary>
        /// The Concur specification demands that each field be separated with a specific character 
        /// </summary>
        public readonly string FieldSeparator;

        /// <summary>
        /// Each ImportDataFile is identified by a Transaction Type Code (ex: 305, 100, 310)
        /// </summary>
        public string Transaction_Type { get;  }

        /// <summary>
        /// Many fields in the uploaded file are not used. 
        /// These unused fields are not included as properties on the ImportDataFiles.
        /// However, we still need to account for them by including the right number of commas in our document
        /// </summary>
        public readonly int Number_Of_Columns;

        /// <summary>
        /// Use FluentValidation to validate each data file
        /// Usage: object.Validate().IsValid
        /// </summary>
        /// <returns></returns>
        public abstract ValidationResult Validate();

        /// <summary>
        /// Each import object needs to be able to transform itself into a comma-separated series of values
        /// </summary>
        /// <param name="printTransactionType"></param>
        /// <returns></returns>
        public abstract string Serialize();

        /// <summary>
        /// Shared set of serialization rules usable only by descendents of ConcurImportFileSection
        /// Child classes must provide a collection of objects and a Type parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Records"></param>
        /// <returns></returns>
        protected string SerializeSection<T>(IEnumerable Records)
        {

            StringBuilder fileSB = new StringBuilder();
            StringBuilder recordSB;
            Dictionary<int, PropertyInfo> fieldIndexes = Helpers.GetFtpFieldIndexes<T>();
            foreach (T er in Records)
            {
                recordSB = new StringBuilder();
                for (int i = 1; i <= this.Number_Of_Columns; i++)
                {
                    string fieldValue = "";
                    if (i == 1 )//&& fileSB.Length == 0)
                    {
                        fieldValue = this.Transaction_Type;
                    }
                    else if (fieldIndexes.Keys.Contains(i))
                    {
                        if (fieldIndexes[i].PropertyType == typeof(bool))
                        {
                            fieldValue = (bool)(fieldIndexes[i].GetValue(er)) == true ? "Y" : "N";
                        }
                        else
                        {
                            fieldValue = fieldIndexes[i].GetValue(er)?.ToString() ?? "";    //? operator to handle nulls
                        }
                    }

                    recordSB.Append(i == 1 ? fieldValue : this.FieldSeparator + fieldValue);
                }

                fileSB.AppendLine(recordSB.ToString());
            }

            return fileSB.ToString();
        }

        
    }
}
