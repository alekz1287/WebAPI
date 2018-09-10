using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur.FTP
{
    /// <summary>
    /// The header fields that appear in a Standard Accounting Extract
    /// </summary>
    public class StandardAccountingExtract_Header : StandardAccountingExtract_Section
    {
        private const int NUMBER_OF_COLUMNS = 5;

        [FtpField(1)]
        public string Constant { get; set; }
        [FtpField(2)]
        public DateTime Batch_Date { get; set; }
        [FtpField(3)]
        public int Record_Count { get; set; }
        [FtpField(4)]
        public decimal Journal_Amount_Total { get; set; }
        [FtpField(5)]
        public string Batch_ID { get; set; }

        public StandardAccountingExtract_Header() : base(NUMBER_OF_COLUMNS)
        {

        }
    }
}
