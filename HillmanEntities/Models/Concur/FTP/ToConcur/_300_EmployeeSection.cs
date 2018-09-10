using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.Text;
using System.Reflection;
using HillmanGroup.API.Models.JDEEntities;
using HillmanGroup.API.Models.Shared;
using AutoMapper;

namespace HillmanGroup.API.Models.Concur
{
    /// <summary>
    /// Expense Primary employee information
    /// </summary>
    public class _300_EmployeeSection : ConcurImportFileSection
    {
        private const string TRANSACTION_TYPE = "300";
        private const int NUMBER_OF_COLUMNS = 86;
        public ICollection<_300_EmployeeRecord> Employee_Records { get; set; }


        public _300_EmployeeSection(ICollection<Employee> employees) : base(TRANSACTION_TYPE, NUMBER_OF_COLUMNS)
        {
            Employee_Records = new List<_300_EmployeeRecord>();
            foreach (Employee emp in employees)
            {
                Employee_Records.Add(Mapper.Map<_300_EmployeeRecord>(emp));
            }
        }       

        /// <summary>
        /// Performs validation and returns a validation result.
        /// Can test the result using ".Validate().IsValid"
        /// </summary>
        /// <returns></returns>
        public override ValidationResult Validate()
        {
            EmployeeImportFile_Validator validator = new EmployeeImportFile_Validator();

            return validator.Validate(this);
        }

        public override string Serialize()
        {
            return base.SerializeSection<_300_EmployeeRecord>(Employee_Records);
        }
    }

    /// <summary>
    /// Validates this entire document by validating each employee record herein
    /// </summary>
    public class EmployeeImportFile_Validator : AbstractValidator<_300_EmployeeSection>
    {
        public EmployeeImportFile_Validator()
        {
            RuleForEach(x => x.Employee_Records).SetValidator(new Employee300_Validator());
        }
    }

    /// <summary>
    /// Represents a single Employee. A "Row" in the import document
    /// </summary>
    public class _300_EmployeeRecord
    {
        [FtpFieldAttribute(2)]
        public string First_Name { get; set; }
        [FtpFieldAttribute(3)]
        public string Middle_Name { get; set; }
        [FtpFieldAttribute(4)]
        public string Last_Name { get; set; }
        [FtpFieldAttribute(5)]
        public string Employee_ID { get; set; }
        [FtpFieldAttribute(6)]
        public string Login_ID { get; set; }
        [FtpFieldAttribute(7)]
        public string Password { get; set; }
        [FtpFieldAttribute(8)]
        public string Email_Address { get; set; }
        [FtpFieldAttribute(9)]
        public string Locale_Code { get; set; }
        [FtpFieldAttribute(10)]
        public string Country_Code { get; set; }
        [FtpFieldAttribute(11)]
        public string Country_Subcode { get; set; }
        [FtpFieldAttribute(12)]
        public string Ledger_Code { get; set; }
        [FtpFieldAttribute(13)]
        public string Reimbursement_Currency_Code { get; set; }
        [FtpFieldAttribute(15)]
        public bool Active { get; set; }
        [FtpFieldAttribute(16)]
        public string Location { get; set; }   //Organizational_Unit_1
        [FtpFieldAttribute(17)]
        public string Department { get; set; }   //Organizational_Unit_2
        [FtpFieldAttribute(38)]
        public string Personnel_Number { get; set; }
        [FtpFieldAttribute(39)]
        public string Payroll_Deductions_Earnings_Code { get; set; }
        [FtpFieldAttribute(40)]
        public string Payroll_ID { get; set; }
        [FtpFieldAttribute(41)]
        public string Payroll_Company_Code { get; set; }
        [FtpFieldAttribute(42)]
        public string Concur_Expense_Group_Hierarchy { get; set; } //This is the default group the employee is associated to: US, CA
        [FtpFieldAttribute(59)]
        public string Employee_ID_Of_Expense_Report_Approver { get; set; }
        [FtpFieldAttribute(63)]
        public bool Is_Expense_User { get; set; }   //Y if employee can create/submit expense reports. 
        [FtpFieldAttribute(64)]
        public bool Is_Approver { get; set; }   //Y if employee is an approver.
        [FtpFieldAttribute(86)]
        public bool Is_Cliqbook_User { get; set; }  //Y if the employee can book travel. 
    }

    /// <summary>
    /// Validates each field in the _300_EmployeeRecord
    /// </summary>
    public class Employee300_Validator : AbstractValidator<_300_EmployeeRecord>
    {
        public Employee300_Validator()
        {
            //RuleFor(cu => cu.Transaction_Type).NotNull();
            RuleFor(cu => cu.First_Name).NotNull().MaximumLength(32);
            RuleFor(cu => cu.Middle_Name).MaximumLength(32);
            RuleFor(cu => cu.Last_Name).NotNull().MaximumLength(32);
            RuleFor(cu => cu.Employee_ID).NotNull().MaximumLength(48);
            RuleFor(cu => cu.Login_ID).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .MaximumLength(64)
                .Must(li => li.Contains("%['#!*&()~`{^}\\|/?><,;:\"+=") == false)
                .WithMessage("{PropertyName} must not contain the following characters: %['#!*&()~`{^}\\|/?><,;:\"+=");

            RuleFor(cu => cu.Password).MaximumLength(30); //Required only for the Travel & Expense (Current UI) product

            RuleFor(cu => cu.Email_Address).MaximumLength(255).EmailAddress();
            RuleFor(cu => cu.Locale_Code).NotNull().MaximumLength(5);
            RuleFor(cu => cu.Country_Code).NotNull().MaximumLength(2);

            RuleFor(cu => cu.Country_Subcode).MaximumLength(6);
            RuleFor(cu => cu.Ledger_Code).NotNull().MaximumLength(20);
            RuleFor(cu => cu.Reimbursement_Currency_Code).NotNull().MaximumLength(6);
            RuleFor(cu => cu.Active).NotNull();

            RuleFor(e => e.Location).MaximumLength(48);
            RuleFor(e => e.Department).MaximumLength(48);

            RuleFor(e => e.Personnel_Number).MaximumLength(48);
            RuleFor(e => e.Payroll_Deductions_Earnings_Code).MaximumLength(48);
            RuleFor(e => e.Payroll_ID).MaximumLength(48);
            RuleFor(e => e.Payroll_Company_Code).MaximumLength(48);
            RuleFor(e => e.Concur_Expense_Group_Hierarchy).MaximumLength(48);
            RuleFor(e => e.Employee_ID_Of_Expense_Report_Approver).MaximumLength(48);
        }
    }
}