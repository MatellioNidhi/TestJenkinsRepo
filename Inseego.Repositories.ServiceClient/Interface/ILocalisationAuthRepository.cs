using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Interface
{
    public interface ILocalisationAuthRepository
    {
        Task<string> GetToken();
        Task<string> GetTokenNew();
    }
}
