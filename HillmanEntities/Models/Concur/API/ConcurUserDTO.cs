using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Concur
{
    //https://fluentvalidation.net/
    public class ConcurUserDTO_Validator : AbstractValidator<ConcurUserDTO>
    {
        public ConcurUserDTO_Validator()
        {
            RuleFor(cu => cu.EmpId).NotNull().MaximumLength(48);
            RuleFor(cu => cu.FeedRecordNumber).NotNull();
            RuleFor(cu => cu.LoginId).NotNull().MaximumLength(128);
            RuleFor(cu => cu.LocaleName).MaximumLength(5);
            RuleFor(cu => cu.Password).NotNull();
            RuleFor(cu => cu.FirstName).MaximumLength(32);
            RuleFor(cu => cu.LastName).MaximumLength(32);
            RuleFor(cu => cu.Mi).MaximumLength(1);
            RuleFor(cu => cu.EmailAddress).MaximumLength(255);
            RuleFor(cu => cu.LedgerKey).MaximumLength(20);

            RuleFor(cu => cu.OrgUnit1).MaximumLength(48);
            RuleFor(cu => cu.OrgUnit2).MaximumLength(48);
            RuleFor(cu => cu.OrgUnit3).MaximumLength(48);
            RuleFor(cu => cu.OrgUnit4).MaximumLength(48);
            RuleFor(cu => cu.OrgUnit5).MaximumLength(48);
            RuleFor(cu => cu.OrgUnit6).MaximumLength(48);

            RuleFor(cu => cu.Custom1).MaximumLength(48);
            RuleFor(cu => cu.Custom2).MaximumLength(48);
            RuleFor(cu => cu.Custom3).MaximumLength(48);
            RuleFor(cu => cu.Custom4).MaximumLength(48);
            RuleFor(cu => cu.Custom5).MaximumLength(48);
            RuleFor(cu => cu.Custom6).MaximumLength(48);
            RuleFor(cu => cu.Custom7).MaximumLength(48);
            RuleFor(cu => cu.Custom8).MaximumLength(48);
            RuleFor(cu => cu.Custom9).MaximumLength(48);
            RuleFor(cu => cu.Custom10).MaximumLength(48);
            RuleFor(cu => cu.Custom11).MaximumLength(48);
            RuleFor(cu => cu.Custom12).MaximumLength(48);
            RuleFor(cu => cu.Custom13).MaximumLength(48);
            RuleFor(cu => cu.Custom14).MaximumLength(48);
            RuleFor(cu => cu.Custom15).MaximumLength(48);
            RuleFor(cu => cu.Custom16).MaximumLength(48);
            RuleFor(cu => cu.Custom17).MaximumLength(48);
            RuleFor(cu => cu.Custom18).MaximumLength(48);
            RuleFor(cu => cu.Custom19).MaximumLength(48);
            RuleFor(cu => cu.Custom20).MaximumLength(48);
            RuleFor(cu => cu.Custom21).MaximumLength(48);

            RuleFor(cu => cu.CtryCode).MaximumLength(2);
            RuleFor(cu => cu.CashAdvanceAccountCode).MaximumLength(20);
            RuleFor(cu => cu.CrnKey).MaximumLength(3);
            RuleFor(cu => cu.CtrySubCode).MaximumLength(2);
            RuleFor(cu => cu.ExpenseApproverEmployeeID).MaximumLength(48);
            RuleFor(cu => cu.NewLoginID).MaximumLength(128);
            RuleFor(cu => cu.NewEmployeeID).MaximumLength(48);
        }
    }

    public class ConcurUserDTO
    {
        /// <summary>
        /// Required. 
        /// The unique identifier for the user. 
        /// The default value is the user’s email address. 
        /// Maximum 48 characters.
        /// JDE
        /// </summary>
        public string EmpId { get; set; }
     
        /// <summary>
        /// Required. 
        /// The number of records in the current batch.
        /// Generated in Code
        /// </summary>
        public string FeedRecordNumber { get; set; }

        /// <summary>
        /// Required. 
        /// The user’s login ID. 
        /// The default value is the user’s email address. 
        /// Maximum 128 characters.
        /// JDE
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// The user’s language locale code.
        /// Maximum 5 characters.
        /// One of the Supported Locales. Example: United States English is en_US.
        /// The supported languages vary by company but always include en_US.
        /// </summary>
        public string LocaleName { get; set; }
        
        /// <summary>
        /// Whether the user is currently active. 
        /// Format: Y/N.J
        /// DE/Generated/Default to Y for new user
        /// </summary>
        public string Active { get; set; }


        /// <summary>
        /// Required.
        /// The user’s password. 
        /// This element can be used to enter the password for a new user, but cannot be used to update the password for an existing user.
        /// Maximum 255 characters.
        /// Default/SSO
        /// </summary>
        public string Password { get; set; }
  
        /// <summary>
        /// The user’s first name.
        /// Maximum 32 characters.
        /// JDE
        /// </summary>
        public string FirstName { get; set; }
  
        /// <summary>
        /// The user’s last name.
        /// Maximum 32 characters.
        /// JDE
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Optional  
        /// The user’s middle initial.
        /// Maximum 1 character.
        /// JDE
        /// </summary>
        public string Mi { get; set; }
        
        /// <summary>
        /// The user’s email address.
        /// Maximum 255 characters.
        /// JDE
        /// </summary>
        public string EmailAddress { get; set; }
     
        /// <summary>
        /// Required for new users.
        /// The user’s assigned account code ledger.
        /// Maximum 20 characters.
        /// Example: Default.
        /// Default based on location
        /// </summary>
        public string LedgerKey { get; set; }

        /// <summary>
        /// OrgUnit1 through OrgUnit6 y   string The custom organizational unit fields on the Employee form.
        /// Varies depending on configuration.
        /// Use the Employee Form Field resource to get the list of configured fields.
        /// Maximum 48 characters for each field.	
        /// OrgUnit1 = Company
        /// OrgUnit2 = Department
        /// </summary>
        public string OrgUnit1 { get; set; }
        public string OrgUnit2 { get; set; }
        public string OrgUnit3 { get; set; }
        public string OrgUnit4 { get; set; }
        public string OrgUnit5 { get; set; }
        public string OrgUnit6 { get; set; }

        /// <summary>
        /// Custom1 through Custom21 
        /// TBD string 
        /// The custom fields on the Employee form. Varies depending on configuration. 
        /// Use the Employee Form Field resource to get the list of configured fields.
        /// Maximum 48 characters.
        /// Custom 15 = Exempt From Approval
        /// Custom 16 = Audit Group
        /// </summary>
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public string Custom6 { get; set; }
        public string Custom7 { get; set; }
        public string Custom8 { get; set; }
        public string Custom9 { get; set; }
        public string Custom10 { get; set; }
        public string Custom11 { get; set; }
        public string Custom12 { get; set; }
        public string Custom13 { get; set; }
        public string Custom14 { get; set; }
        public string Custom15 { get; set; }
        public string Custom16 { get; set; }
        public string Custom17 { get; set; }
        public string Custom18 { get; set; }
        public string Custom19 { get; set; }
        public string Custom20 { get; set; }
        public string Custom21 { get; set; }

        
        /// <summary>
        /// The ISO 3166-1 alpha-2 country code. 
        /// Maximum 2 characters.
        /// Example: United States is US.
        /// Does JDE / Dayforce have ISO code?
        /// </summary>
        public string CtryCode { get; set; }

        /// <summary>
        /// Optional or N. 
        /// The user’s account code for cash advances. 
        /// Maximum 20 characters.   
        /// ?
        /// </summary>
        public string CashAdvanceAccountCode { get; set; }

        /// <summary>
        /// The 3-letter ISO 4217 currency code for the user’s reimbursement currency. 
        /// Maximum 3 characters.
        /// Example: United States Dollar is USD.
        /// Default on location/JDE
        /// </summary>
        public string CrnKey { get; set; }

        /// <summary>
        /// The user’s two-character country code and two-character state or province code. 
        /// Maximum 2 characters.Example: Washington State, United States is US-WA.
        /// Generated in code
        /// </summary>
        public string CtrySubCode { get; set; }
        
        /// <summary>
        /// Whether the user has access to Expense.	
        /// Default Y
        /// </summary>
        public bool  ExpenseUser { get; set; }

        /// <summary>
        /// Management. 
        /// Whether the user is an Expense approver.
        /// Mngt = y Employee = N
        /// </summary>
        public bool ExpenseApprover { get; set; }
        
        /// <summary>
        /// Trip Users Only. 
        /// Whether the user has access to Travel.	
        /// Is this stored in JDE or DayForce?
        /// </summary>
        public bool TripUser { get; set; }

        /// <summary>
        /// Whether the user has access to Invoice.	
        /// Default N
        /// </summary>
        public bool InvoiceUser { get; set; }
        
        /// <summary>
        /// Whether the user is an Invoice approver.
        /// Default N
        /// </summary>
        public bool InvoiceApprover { get; set; }

        /// <summary>
        /// The employee ID of the user’s Expense approver.
        /// Maximum 48 characters.
        /// If you are importing both a user and their approver, the approver should be listed before the user in the batch.	
        /// JDE/Dayforce/Generate in code
        /// </summary>
        public string ExpenseApproverEmployeeID { get; set; }

        /// <summary>
        /// Use this element to change the Login ID for an existing employee.
        /// Maximum 128 characters.
        /// </summary>
        public string NewLoginID { get; set; }
        
        /// <summary>
        /// Use this element to change the Employee ID for an existing employee.
        /// Maximum 48 characters.
        /// </summary>
        public string NewEmployeeID { get; set; }
    }
}
