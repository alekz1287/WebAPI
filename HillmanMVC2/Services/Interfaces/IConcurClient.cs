using HillmanGroup.API.Models.Concur;
using HillmanGroup.API.Models.Concur.FTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanMVC2.Services.Interfaces
{
    public interface IConcurClient
    {
        string BaseUrl { get; set; }

        Task ImportEmployeesAsync(ConcurImportDataFile ftpFile);

        Task<System.Collections.ObjectModel.ObservableCollection<StandardAccountingExtract>> GetStandardAccountingExtractsAsync();

        Task<string> GetEditionTypeAsync();

    }
}
