using System.Collections.Generic;
using HillmanGroup.API.Models.Concur.FTP;
using HillmanGroup.API.Models.JDEEntities;
using HillmanGroup.API.Models.Shared;

namespace HillmanGroup.API.Services
{
    public interface IJDEdwardsRepository
    {
        ICollection<Employee> GetEmployees(int numberOfRows);

        ICollection<Employee> GetEmployees();

        void InsertTransactions(ICollection<StandardAccountingExtract> saes);
    }
}