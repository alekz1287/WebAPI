using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanMVC2.Services.Interfaces
{
    public interface IIntegrationClient
    {
        string BaseUrl { get; set; }

        Task SendEmployeesToConcurAsync();

        Task GetExpenseDataFromConcurAsync();
    }
}
