using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace HillmanGroup.API.Models.Concur
{
    public enum Password_Generation_Options { EMPID, LOGINID, TEXT, WELCOME, SSO };
    public enum Existing_Record_Handling_Options { REPLACE, UPDATE, WARN, IGNORE };

    /// <summary>
    /// The first row of any document that we upload to Concur must be a _100_ImportSettings 
    /// </summary>
    public class _100_ImportSettings : ConcurImportFileSection
    {
        private const string TRANSACTION_TYPE = "100";
        private const int NUMBER_OF_COLUMNS = 7;
        public List<_100_ImportRecord> Import_Settings_records { get; set; }
       

        public _100_ImportSettings() : base(TRANSACTION_TYPE, NUMBER_OF_COLUMNS)
        {
            Import_Settings_records = new List<_100_ImportRecord>();
            Import_Settings_records.Add(new _100_ImportRecord());
        }

        public override ValidationResult Validate()
        {
            ImportSettingsFile_Validator validator = new ImportSettingsFile_Validator();
            return validator.Validate(this);
        }

        public override string Serialize()
        {
            return base.SerializeSection<_100_ImportRecord>(Import_Settings_records);
        }
    }

    /// <summary>
    /// Validates this entire document by validating each import setting record herein
    /// </summary>
    public class ImportSettingsFile_Validator : AbstractValidator<_100_ImportSettings>
    {
        public ImportSettingsFile_Validator()
        {
            RuleForEach(x => x.Import_Settings_records).SetValidator(new Settings100_Validator());
            //RuleFor(x => x.Import_Settings_records).SetCollectionValidator(new Settings100_Validator());
        }
    }

    /// <summary>
    /// Represents a single _100_Import row. 
    /// Little strange in this case because there should only ever be one row per import document
    /// But it's helpful for each section of the document to conform to the same rules
    /// </summary>
    public class _100_ImportRecord
    {
        [FtpFieldAttribute(2)]
        public int Error_Threshhold { get; }
        [FtpFieldAttribute(3)]
        public Password_Generation_Options Password_Generation { get; set; }
        [FtpFieldAttribute(4)]
        public Existing_Record_Handling_Options Existing_Record_Handling { get; set; }
        [FtpFieldAttribute(5)]
        public string Language_Code { get; set; }
        [FtpFieldAttribute(6)]
        public bool Validate_Expense_Group { get; set; }
        [FtpFieldAttribute(7)]
        public bool Validate_Payment_Group { get; set; }

        public _100_ImportRecord()
        {
            Error_Threshhold = 0;
            Password_Generation = Password_Generation_Options.WELCOME;
            Existing_Record_Handling = Existing_Record_Handling_Options.UPDATE;
            Language_Code = "EN";
            Validate_Expense_Group = false;
            Validate_Payment_Group = false;
        }
    }

    /// <summary>
    /// This validator ensures that each field in the _100_ImportRecord conforms to the rules set by Concur
    /// </summary>
    public class Settings100_Validator : AbstractValidator<_100_ImportRecord>
    {
        public Settings100_Validator()
        {
            RuleFor(x => x.Error_Threshhold).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Password_Generation).NotNull();
            RuleFor(x => x.Existing_Record_Handling).NotNull();
            RuleFor(x => x.Language_Code).NotNull();
            RuleFor(x => x.Validate_Expense_Group).NotNull();
            RuleFor(x => x.Validate_Payment_Group).NotNull();
        }
    }
}
