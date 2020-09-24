using Inseego.Repositories.ServiceClient.Model;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Interface
{
    public interface IPersonaRepository
    {
        Task<DriverInfo> GetDriverInfo(string[] ids);
    }
}
