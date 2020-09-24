using System.Collections.Generic;
using Inseego.Models.Request;
using Inseego.Models.Response;

namespace Inseego.Services.Interface
{
    public interface IServiceTypeService
    {
        ServiceTypesResponse CreateServiceTypes(ServiceTypeCreateRequest request, string UserId, string TenantId);
        List<ServiceTypesResponse> ServiceTypes(string[] ServiceTypeids, string TenantId, string UserId);
        ServiceTypesResponse UpdateServiceTypes(ServiceTypeUpdateRequest request, string UserId, string TenantId);
        bool DeleteServiceTypes(ServiceTypeDeleteRequest request, string UserId, string TenantId);
        ServiceTypesResponse SetDeletedServiceTypes(ServiceTypeDeleteRequest request, string UserId, string TenantId);


    }
}
