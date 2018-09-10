using HillmanGroup.API.Models.ActiveDirectory;
using System.Threading;
using System.Threading.Tasks;

namespace HillmanMVC2.Services.Interfaces
{
    public interface IActiveDirectoryClient
    {
        string BaseUrl { get; set; }

        Task<ActiveDirectoryUser> GetEmployeeByEmailAsync(string emailAddress);
        Task<ActiveDirectoryUser> GetEmployeeByEmailAsync(string emailAddress, CancellationToken cancellationToken);
        Task<System.Collections.ObjectModel.ObservableCollection<ActiveDirectoryUser>> GetEmployeesFromLDAPAsync(string searchBase);
        Task<System.Collections.ObjectModel.ObservableCollection<ActiveDirectoryUser>> GetEmployeesFromLDAPAsync(string searchBase, CancellationToken cancellationToken);
        Task<System.Collections.ObjectModel.ObservableCollection<ActiveDirectoryUser>> GetEmployeesFromLDAPAllAsync();
        Task<System.Collections.ObjectModel.ObservableCollection<ActiveDirectoryUser>> GetEmployeesFromLDAPAllAsync(CancellationToken cancellationToken);
        Task<System.Collections.ObjectModel.ObservableCollection<OrganizationalUnit>> GetOrganizationsAllAsync();
        Task<System.Collections.ObjectModel.ObservableCollection<OrganizationalUnit>> GetOrganizationsAllAsync(System.Threading.CancellationToken cancellationToken);
        Task<System.Collections.ObjectModel.ObservableCollection<OrganizationalUnit>> GetOrganizationsAsync(string searchBase);
        Task<System.Collections.ObjectModel.ObservableCollection<OrganizationalUnit>> GetOrganizationsAsync(string searchBase, System.Threading.CancellationToken cancellationToken);


    }
}