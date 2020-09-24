using Inseego.Repositories.ServiceClient.Model;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Interface
{
    public interface IConfigTenantRepository
    {
        Task<GYRData> GetGYRData();
        Task<ConfigurationSetting> GetConfigurationSetting();
    }
}
