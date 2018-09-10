using HillmanGroup.API.Models.JDEEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Models.Shared
{
    /// <summary>
    /// This class is meant to be a generic Employee record.
    /// It serves as an intermediary between the JDE tables and the Concur DTOs
    /// </summary>
    public class Employee
    {
        private const string DEFAULT_PASSWORD = "welcome";

        //TODO: These need to come fr
        private const string DEFAULT_LOCALE_CODE = "en_US";
        private const string DEFAULT_COUNTRY_CODE = "US";
        private const string DEFAULT_LEDGER_CODE = "JDE"; //Either "JDE" or "Canada Ledger"
        private const string DEFAULT_REIMBURSEMENT_CURRENCY_CODE = "USD";
        private const string DEFAULT_LOCATION_CODE = "USCVG";

        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Employee_ID { get; set; }
        public string Login_ID { get; set; }
        public string Password { get; set; }
        public string Email_Address { get; set; }
        public string Locale_Code { get; set; }
        public string Country_Code { get; set; }
        public string Country_Subcode { get; set; }
        public string Ledger_Code { get; set; }
        public string Reimbursement_Currency_Code { get; set; }
        public bool Active { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Personnel_Number { get; set; }
        public string Payroll_Deductions_Earnings_Code { get; set; }
        public string Payroll_ID { get; set; }
        public string Payroll_Company_Code { get; set; }
        public string Concur_Expense_Group_Hierarchy { get; set; } //This is the default group the employee is associated to: US, CA
        public string Employee_ID_Of_Expense_Report_Approver { get; set; }
        public bool Is_Expense_User { get; set; }   //Y if employee can create/submit expense reports. 
        public bool Is_Approver { get; set; }   //Y if employee is an approver.
        public bool Is_Cliqbook_User { get; set; }  //Y if the employee can book travel. 

        public Employee()
        {

        }

        public Employee(F0101 addressBook, F0092 managerProfile, F0092 profile, F20103 hierarchy)
        {
            (string firstName, string lastName) nameParts = parseName(addressBook.Abalph);
            this.First_Name = nameParts.firstName;
            this.Middle_Name = "";
            this.Last_Name = nameParts.lastName;
            this.Employee_ID = profile.Ulan8.ToString();
            //this.Login_ID = profile.Uluser.Trim() + emailDomain;
            this.Password = DEFAULT_PASSWORD;
            //this.Email_Address = profile.Uluser.Trim() + emailDomain;
            this.Locale_Code = DEFAULT_LOCALE_CODE;
            this.Country_Code = DEFAULT_COUNTRY_CODE; //TODO: Change for CA records;
            this.Ledger_Code = DEFAULT_LEDGER_CODE;
            this.Reimbursement_Currency_Code = DEFAULT_REIMBURSEMENT_CURRENCY_CODE;
            this.Active = true; //TODO: find this value, it is required
            this.Location = DEFAULT_LOCATION_CODE; 
            this.Department = "Department Code";   
            this.Personnel_Number = ""; //TODO: find this value, it is suggested in xls
            this.Payroll_Deductions_Earnings_Code = ""; //TODO: find this value, it is suggested in xls
            this.Payroll_ID = ""; //TODO: find this value, it is suggested in xls
            this.Payroll_Company_Code = ""; //TODO: find this value, it is suggested in xls
            this.Concur_Expense_Group_Hierarchy = "US"; //TODO: find this value, it is suggested in xls
            this.Employee_ID_Of_Expense_Report_Approver = managerProfile.Ulan8.ToString();//.HasValue ? hierarchy.Epmgrid.Value.ToString().Trim() : "";
            this.Is_Expense_User = true; //TODO: find this value, it is suggested in xls
            this.Is_Approver = false; //TODO: find this value, it is suggested in xls
            this.Is_Cliqbook_User = false; //TODO: find this value, it is suggested in xls
        }

        /// <summary>
        /// Parses the messy data found in the ABALPH column of the address book
        /// Converts it to a tuple containing first and last name
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private (string firstName, string lastName) parseName(string input)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string[] stringParts = input.Split(" ");

            if (stringParts.Length >= 2)
            {
                if (input.Contains(","))
                {
                    lastName = stringParts[0].Replace(",", "").Trim();
                    firstName = stringParts[1].Trim();
                }
                else
                {
                    firstName = stringParts[0].Trim();
                    lastName = stringParts[1].Trim();
                }
            }
            
            return (firstName, lastName);
        }

    }
}
