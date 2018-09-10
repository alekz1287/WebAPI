using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur.FTP
{
    /// <summary>
    /// Base class for SAE headers and details.
    /// Both of these types exist as rows in the SAE excel sheet
    /// This class provides shared functionality for transforming that excel row into the corresponding object
    /// </summary>
    public abstract class StandardAccountingExtract_Section
    {
        public int Number_of_Columns { get; }

        public StandardAccountingExtract_Section(int numberOfColumns)
        {
            Number_of_Columns = numberOfColumns;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelRow"></param>
        public void DeserializeFrom<T>(IXLRangeRow excelRow)
        {
            Dictionary<int, PropertyInfo> propertyIndexes = Helpers.GetFtpFieldIndexes<T>();

            for (int i = 1; i <= this.Number_of_Columns; i++)
            {
                try
                {
                    if (propertyIndexes.Keys.Contains(i))
                    {
                        switch (GetTypeCode(propertyIndexes[i].PropertyType))
                        {
                            // Type code doesn't have reference with int, long, etc.,
                            case TypeCode.DateTime:
                                if(DateTime.TryParse(excelRow.Cell(i).GetString(), out DateTime parsedDate))
                                {
                                    propertyIndexes[i].SetValue(this, parsedDate);
                                }
                                else
                                {
                                    propertyIndexes[i].SetValue(this, null);
                                }                                
                                break;
                            case TypeCode.Int32:
                                Int32.TryParse(excelRow.Cell(i).GetString(), out int parsedInt);
                                propertyIndexes[i].SetValue(this, parsedInt);
                                break;
                            case TypeCode.Decimal:
                                Decimal.TryParse(excelRow.Cell(i).GetString(), out decimal parsedDecimal);
                                propertyIndexes[i].SetValue(this, parsedDecimal);
                                break;
                            case TypeCode.Boolean:
                                propertyIndexes[i].SetValue(this, excelRow.Cell(i).GetString() == "Y");
                                break;
                            default:
                                propertyIndexes[i].SetValue(this, excelRow.Cell(i).GetString());
                                break;
                        }
                    }
                }catch(Exception e)
                {
                    throw new Exception($"Error attempting to deserialize the SAE file into a {typeof(T)}. "
                        + $"Error occurred in cell {Helpers.GetExcelColumnName(i)}{excelRow.RowNumber()} when " 
                        + $"trying to convert \"{excelRow.Cell(i).GetString()}\" to a {Type.GetTypeCode(propertyIndexes[i].PropertyType)}."
                        , e);
                }
            }
        }

        /// <summary>
        /// Given a type, returns the typecode
        /// This only exists because C# can't switch on types, but can on TypeCodes
        /// and TypeCodes don't play nice with Nullable types
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public TypeCode GetTypeCode(Type inputType)
        {
            if (inputType.Equals(typeof(DateTime?)))
            {
                return TypeCode.DateTime;
            }
            else
            {
                return Type.GetTypeCode(inputType);
            }
        }
    }
}
