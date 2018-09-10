using HillmanGroup.API.Models.Concur.FTP;
using HillmanGroup.API.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanMVC2.Services.Interfaces
{
    public interface IJDEdwardsClient
    {
        string BaseUrl { get; set; }

        Task<System.Collections.ObjectModel.ObservableCollection<Employee>> GetEmployeesCountAsync(int numberOfRows);

        Task InsertExpenseDataAsync(IEnumerable<StandardAccountingExtract> saes);

    }
}
