using System;
using System.Collections.Generic;
using Inseego.Services.Interface;
using Inseego.Models.Request;
using Inseego.Models.Response;
using System.Threading.Tasks;
using Inseego.Repositories.CosmosDB.Model;
using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Utilities;
using System.Linq;

namespace Inseego.Services.Implementation
{
    public class LicenseTypesService : ILicenseTypeService
    {
        private ICosmosDBOperationsRepository<LicenseTypesModel> _cosmosDBOperationsRepository;
        private readonly string licenseTypeCollectionId = "LicenseType";

        public LicenseTypesService(ICosmosDBOperationsRepository<LicenseTypesModel> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }
        public LicenseTypesResponse CreateLicenseTypes(LicenseTypeCreateRequest request, string UserId, string TenantId)
        {
            LicenseTypesResponse responseModel = new LicenseTypesResponse();
            LicenseTypesModel licenseTypesModel = new LicenseTypesModel();

            licenseTypesModel.licenseTypeName = request.LicenseTypeName;

            licenseTypesModel.userId = UserId;
            licenseTypesModel.tenantId = TenantId;

            licenseTypesModel.createdBy = UserId;
            licenseTypesModel.createdDate = DateTime.UtcNow;

            licenseTypesModel.modifiedBy = UserId;
            licenseTypesModel.modifiedDate = DateTime.UtcNow;
                        
            licenseTypesModel.isActive = true;
            licenseTypesModel.isDeleted = false;

            //// Run below line First time only
            //_cosmosDBOperationsRepository.CreateCollectionIfNotExistsAsync(licenseTypeCollectionId);

            LicenseTypesModel result = _cosmosDBOperationsRepository.AddDocumentIntoCollectionAsync(licenseTypesModel, UserId.Trim().ToString(), TenantId, licenseTypeCollectionId).Result;
            CommonFunctions.CopyProperties(result, responseModel);
            return responseModel;
        }

        public List<LicenseTypesResponse> LicenseTypes(string[] LicenseTypeids, string TenantId, string UserId)
        {
            string where = string.Empty;
            string selectLocationQuery = string.Empty;

            List<LicenseTypesResponse> response = new List<LicenseTypesResponse>();
            if (LicenseTypeids.Contains("all"))
            {
                selectLocationQuery = $"SELECT * FROM c where c.tenantId='" + TenantId + "' and c.userId='" + UserId + "' and c.isActive=true order by c.createdDate desc";                
            }
            else
            {
                selectLocationQuery = $"SELECT * FROM c where c.id in ('" + String.Join(",", LicenseTypeids) + "') and c.tenantId='" + TenantId + "' and c.userId='" + UserId + "' and c.isActive=true order by c.createdDate desc";
            }
            List<LicenseTypesModel> data = _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync<LicenseTypesModel>(selectLocationQuery, where, TenantId, licenseTypeCollectionId).Result;
            if (data != null && data.Count != 0)
            {
                foreach (var item in data)
                {
                    LicenseTypesResponse idata = new LicenseTypesResponse();
                    CommonFunctions.CopyProperties(item, idata);
                    response.Add(idata);
                }
            }
            return response;    //?.FirstOrDefault();
        }       

        public LicenseTypesResponse UpdateLicenseTypes(LicenseTypeUpdateRequest request, string UserId, string TenantId)
        {
            LicenseTypesResponse responseModel = new LicenseTypesResponse();

            LicenseTypesModel licenseTypesModel = GetLicenseTypeById(request, TenantId, out LicenseTypesStatusModel licenseTypesStatus);

            if (licenseTypesStatus.IsLicenseTypesFound)
            {   
                licenseTypesModel.licenseTypeName = request.LicenseTypeName;
                licenseTypesModel.modifiedBy = UserId;
                licenseTypesModel.modifiedDate = DateTime.UtcNow;

                LicenseTypesModel result = _cosmosDBOperationsRepository.UpdateDocumentFromCollection(licenseTypesModel.id, licenseTypesModel, TenantId, licenseTypeCollectionId).Result;
                CommonFunctions.CopyProperties(result, responseModel);
            }
            return responseModel;
        }

        public LicenseTypesModel GetLicenseTypeById(LicenseTypeUpdateRequest request, string tenantId, out LicenseTypesStatusModel licenseTypesStatus)
        {
            if (!string.IsNullOrWhiteSpace(request.id))
            {
                request.id = request.id.ToLower();
            }

            licenseTypesStatus = new LicenseTypesStatusModel();
            string query = $" WHERE LOWER({licenseTypeCollectionId}.id) = '{request.id}'";
            LicenseTypesModel result = _cosmosDBOperationsRepository.GetItemByQueryFromCollectionAsync(
                query, tenantId, licenseTypeCollectionId).Result;

            if (result == null)
            {
                licenseTypesStatus.Message = String.Format($"License type '{request.LicenseTypeName}' not found");
                return null;
            }

            licenseTypesStatus.IsLicenseTypesFound = true;
            return result;
        }

        public bool DeleteLicenseTypes(LicenseTypeDeleteRequest request, string UserId, string TenantId)
        {
            LicenseTypesResponse responseModel = new LicenseTypesResponse();
            LicenseTypesModel licenseTypesModel = new LicenseTypesModel();

            bool result = _cosmosDBOperationsRepository.DeleteDocumentFromCollectionAsync(request.id, TenantId, licenseTypeCollectionId).Result;
            return result;
        }

        public LicenseTypesResponse SetDeletedLicenseTypes(LicenseTypeDeleteRequest request, string UserId, string TenantId)
        {
            LicenseTypesResponse responseModel = new LicenseTypesResponse();

            LicenseTypesModel licenseTypesModel = GetLicenseTypeByIdForDelete(request, TenantId, out LicenseTypesStatusModel licenseTypesStatus);

            if (licenseTypesStatus.IsLicenseTypesFound)
            {
                licenseTypesModel.id = request.id;

                licenseTypesModel.isActive = false;
                licenseTypesModel.isDeleted = true;

                licenseTypesModel.modifiedBy = UserId;
                licenseTypesModel.modifiedDate = DateTime.UtcNow;

                LicenseTypesModel result = _cosmosDBOperationsRepository.UpdateDocumentFromCollection(request.id, licenseTypesModel, TenantId, licenseTypeCollectionId).Result;
                CommonFunctions.CopyProperties(result, responseModel);
            }
            return responseModel;
        }

        public LicenseTypesModel GetLicenseTypeByIdForDelete(LicenseTypeDeleteRequest request, string tenantId, out LicenseTypesStatusModel licenseTypesStatus)
        {
            if (!string.IsNullOrWhiteSpace(request.id))
            {
                request.id = request.id.ToLower();
            }

            licenseTypesStatus = new LicenseTypesStatusModel();
            string query = $" WHERE LOWER({licenseTypeCollectionId}.id) = '{request.id}'";
            LicenseTypesModel result = _cosmosDBOperationsRepository.GetItemByQueryFromCollectionAsync(
                query, tenantId, licenseTypeCollectionId).Result;

            if (result == null)
            {
                licenseTypesStatus.Message = String.Format($"License type '{request.id}' not found");
                return null;
            }

            licenseTypesStatus.IsLicenseTypesFound = true;
            return result;
        }
    }
}
