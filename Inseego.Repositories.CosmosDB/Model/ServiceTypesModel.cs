using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.CosmosDB.Model
{
    public class ServiceTypesModel
    {
        public string id { get; set; }
        public string serviceTypeName { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public string tenantId { get; set; }
        public string userId { get; set; }
    }
}
