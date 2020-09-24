using Inseego.Repositories.ServiceClient.Model;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Interface
{
    public interface IDeviceRepository
    {
        Task<TenantVehicleInfo> GetTenantVehicleInfo();
    }
}
