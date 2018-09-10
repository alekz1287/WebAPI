using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur.FTP
{
    public class StandardAccountingExtract
    {
        public StandardAccountingExtract_Header Header { get; set; }
        public List<StandardAccountingExtract_Detail> Details { get; set; }
        public string FilePath { get; set; }

        public StandardAccountingExtract()
        {

        }

        /// <summary>
        /// If a filepath is provided, remember it and attempt to load the file at that path
        /// </summary>
        /// <param name="filePath"></param>
        public StandardAccountingExtract(string filePath)
        {
            FilePath = filePath;
            LoadExcel(FilePath);
        }

        /// <summary>
        /// Parses a Standard Accounting Extract document according to the Concur spec
        /// </summary>
        /// <param name="excelFilePath"></param>
        public void LoadExcel(string excelFilePath)
        {
            var wb = new XLWorkbook(excelFilePath);
            var ws = wb.Worksheet(1);

            // Look for the first row used
            var firstRowUsed = ws.FirstRowUsed();

            // Narrow down the row so that it only includes the used part
            var headerRow = firstRowUsed.RowUsed();

            //Get the property-index dictionary
            //use it to extract the values from the row
            Header = new StandardAccountingExtract_Header();
            Header.DeserializeFrom<StandardAccountingExtract_Header>(headerRow);

            //Loop through remaining rows to get the details records
            Details = new List<StandardAccountingExtract_Detail>();
            var detailRow = headerRow.RowBelow();
            while (!detailRow.Cell(1).IsEmpty())
            {
                var detail = new StandardAccountingExtract_Detail();
                detail.DeserializeFrom<StandardAccountingExtract_Detail>(detailRow);
                Details.Add(detail);

                //Advance to next row
                detailRow = detailRow.RowBelow();
            }
        }
        
    }
}
