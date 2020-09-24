using System.Collections.Generic;
using Inseego.Models.Request;
using Inseego.Models.Response;

namespace Inseego.Services.Interface
{
    public interface ILicenseTypeService
    {
        LicenseTypesResponse CreateLicenseTypes(LicenseTypeCreateRequest request, string UserId, string TenantId);
        List<LicenseTypesResponse> LicenseTypes(string[] LicenseTypeids, string TenantId, string UserId);
        LicenseTypesResponse UpdateLicenseTypes(LicenseTypeUpdateRequest request, string UserId, string TenantId);
        bool DeleteLicenseTypes(LicenseTypeDeleteRequest request, string UserId, string TenantId);
        LicenseTypesResponse SetDeletedLicenseTypes(LicenseTypeDeleteRequest request, string UserId, string TenantId);


    }
}
