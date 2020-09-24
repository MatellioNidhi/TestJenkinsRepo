using System;

namespace Inseego.Repositories.CosmosDB.Model
{
    public class LicenseTypesModel
    {
        public string id { get; set; }
        public string licenseTypeName { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public string tenantId { get; set; }
        public string userId { get; set; }
    }

    public class LicenseTypesStatusModel
    {
        public bool IsLicenseTypesFound { get; set; }
        public bool IsRequestValid { get; set; }
        public string Message { get; set; }

        public LicenseTypesStatusModel()
        {
            IsLicenseTypesFound = false;
            IsRequestValid = true;
        }
    }
}
