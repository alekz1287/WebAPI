using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.JDEEntities;
using System.Text;
using FluentValidation.Results;
using HillmanGroup.API.Models.Shared;
using IBM.Data.DB2.Core;
using System.Data;
using HillmanGroup.API.Models.Concur.FTP;
using Microsoft.EntityFrameworkCore;

namespace HillmanGroup.API.Services
{
    public class JDEdwardsRepository : IJDEdwardsRepository
    {
        private JDEContext _context;

        public JDEdwardsRepository(JDEContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Given a collection of StandardAccountingExtracts, updates the corresponding zTable (F0411z1) in JDEdwards
        /// by inserting new transactions
        /// For an explanation of fields in enterprise one, see this link:
        /// https://docs.oracle.com/cd/E64610_01/EOAAP/map_vcher_trsctn_to_btch_ip.htm#EOAAP00593
        /// </summary>
        /// <param name="saes"></param>
        public void InsertTransactions(ICollection<StandardAccountingExtract> saes)
        {
            using (DB2Connection conn = new DB2Connection(_context.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();

                //using (DB2Transaction tran = conn.BeginTransaction(IsolationLevel))
                //{
                using (DB2Command dbCommand = conn.CreateCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    string commandText = "INSERT INTO hilldta.F0411Z1 (VLEDUS,VLEDTN,VLEDLN,VLEDTC,VLEDTR,VLEDBT,VLAN8,VLDGJ,VLCO,VLGLC,VLAG,VLGLBA,VLMCU,VLRMK) VALUES ";
                    //dbCommand.Transaction = tran;
                    dbCommand.CommandType = CommandType.Text;
                    
                    foreach(StandardAccountingExtract sae in saes)
                    {
                        foreach(StandardAccountingExtract_Detail transaction in sae.Details)
                        {
                            //ENTITY FRAMEWORK ISN'T WORKING BECAUSE JOURNALING IS NOT ENABLED!
                            //F0411z1 record = new F0411z1();
                            //record.Vledus = "CONCUR";
                            //record.Vledtn = transaction.Sequence_Number.ToString();
                            //Decimal.TryParse(transaction.Report_Entry_Id, out decimal parsedLineNumber);
                            //record.Vledln = parsedLineNumber;
                            //record.Vledtc = "A";
                            //record.Vledtr = "V";
                            //record.Vledbt = sae.Header.Batch_ID;
                            //Decimal.TryParse(transaction.Report_Entry_Id, out decimal parsedEmployeeID);
                            //record.Vlan8 = parsedEmployeeID;
                            //Decimal.TryParse(ConvertDateToJulianDate(DateTime.Now), out decimal parsedDate);
                            //record.Vldgj = parsedDate;
                            //record.Vlco = transaction.Employee_Org_Unit_1;
                            //record.Vlglc = " ";
                            //record.Vlag = transaction.Total_Approved_Amount;
                            //record.Vlglba = " ";
                            //record.Vlmcu = transaction.Employee_Org_Unit_2;
                            //record.Vlrmk = transaction.Report_Entry_Expense_Type_Name;



                            if (sb.Length > 0)
                            {
                                sb.Append(", ");
                            }
                            sb.Append($"('CONCUR','{transaction.Sequence_Number}',{transaction.Report_Entry_Id},'A'"
                                + $",'V','{sae.Header.Batch_ID}',{transaction.Employee_ID},{ConvertDateToJulianDate(DateTime.Now)},"
                                + $"'{transaction.Employee_Org_Unit_1}',' ',{transaction.Total_Approved_Amount},' ','{transaction.Employee_Org_Unit_2}',"
                                + $"'{transaction.Report_Entry_Expense_Type_Name}')");

                        }
                    }

                    sb.Append(" WITH NONE");

                    dbCommand.CommandText = commandText + sb.ToString();
                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Enterprise one stores dates in "EnterpriseOne Julian" format. 
        /// CYYDDD where C = Century; YY = a 2 digit year; and DD = the 3 digit number representing the day of the year 
        /// (1 through 365 or 366 days on a leap year).  
        /// The Century is either a 1 or 0 depending on whether you’re using year 2000 + or if you’re using dates in the 1900’s
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string ConvertDateToJulianDate(DateTime input)
        {
            string C = input.Year >= 2000 ? "1" : "0";
            string YYDDD = input.Year.ToString().Substring(2) + input.DayOfYear.ToString();

            return C + YYDDD;
        }

        /// <summary>
        /// Calls GetEmployees and returns ALL records. Can't use an optional parameter because of Interfaces
        /// </summary>
        /// <returns></returns>
        public ICollection<Employee> GetEmployees()
        {
            return GetEmployees(-1);
        }

        /// <summary>
        /// Returns a list of Employee objects by combining the data from F0101, F20103, and F0092
        /// </summary>
        /// <returns></returns>
        public ICollection<Employee> GetEmployees(int numberOfRows)
        {
            List<Employee> employees = new List<Employee>();

            //Get all the data we can
            var rawEmployees = (from address in _context.F0101
                                join hierarchy in _context.F20103 on address.Aban8 equals hierarchy.Epemployid
                                join managerProfile in _context.F0092 on hierarchy.Epmgrid equals managerProfile.Ulan8
                                join profile in _context.F0092 on address.Aban8 equals profile.Ulan8
                                where address.Abat1 == "EM"
                                select new
                                {
                                    Address = address,
                                    ManagerProfile = managerProfile,
                                    Profile = profile,
                                    Hierarchy = hierarchy

                                }).OrderBy(x => x.Address.Abalph).AsQueryable();

            if (numberOfRows > 0)
            {
                rawEmployees = rawEmployees.Take(numberOfRows);
            }

            if(rawEmployees != null)
            {
                foreach (var emp in rawEmployees.ToList())
                {
                    employees.Add(new Employee(emp.Address, emp.ManagerProfile, emp.Profile, emp.Hierarchy));
                }
            }
            

            return employees;

            //SELECT addressBook.abalph as EmployeeName, profile.epemployid as EmployeeID, addressBook2.abalph as ManagerName, profile.epmgrid as ManagerID
            //FROM hilldta.F0101 addressBook
            //JOIN hilldta.F20103 profile
            //ON addressBook.aban8 = profile.epemployid
            //JOIN hilldta.F0101 addressBook2
            //ON addressBook2.aban8 = profile.epmgrid
        }
    }
}
