using Inseego.Repositories.ServiceClient.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Interface
{
    public interface ILocalisationRepository
    {
        Task<List<LocalisationModel>> GetLocalisationByModule(string culture, string token);
    }
}
