using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using FluentValidation.Results;

namespace HillmanGroup.API.Models.Concur
{
    /// <summary>
    /// Reprents a complete file that could be uploaded to Concur
    /// Should contain 100_ImportSettings header and Section of Details records
    /// </summary>
    public class ConcurImportDataFile
    {
        private ConcurImportFileSection _header;
        private ConcurImportFileSection _detailsSection
            ;

        public ConcurImportDataFile(ConcurImportFileSection section)
        {
            _header = new _100_ImportSettings();
            _detailsSection = section;
        }


       
        /// <summary>
        /// Validates all sections contained in the document.
        /// Retuns a validation result containing all errors that are found
        /// </summary>
        /// <returns></returns>
        public ValidationResult Validate()
        {
            ValidationResult results = new ValidationResult();

            ValidationResult headerResult = _header.Validate();
            ValidationResult sectionResult = _detailsSection.Validate();

            results.Errors.Concat(headerResult.Errors);
            results.Errors.Concat(sectionResult.Errors);

            return results;
        }

        /// <summary>
        /// Serializes all sections of the document and returns a string that is properly formatted for FTP upload to Concur
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            //Serialize both the header and the import details section
            StringBuilder sb = new StringBuilder();
            
            sb.Append(_header.Serialize());
            sb.Append(_detailsSection.Serialize());

            return sb.ToString();
        }
    }
}
