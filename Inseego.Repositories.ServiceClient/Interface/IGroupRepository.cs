using Inseego.Repositories.ServiceClient.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Interface
{
    public interface IGroupRepository
    {
        Task<List<GroupHierarchyModel>> GetGroupHierarchy();
    }
}
