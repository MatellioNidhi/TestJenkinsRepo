using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.ServiceClient.Model
{
    public class GroupHierarchyModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }

        [JsonProperty("currentGroup")]
        public CurrentGroup CurrentGroup { get; set; }

        [JsonProperty("groupChildren")]
        public List<GroupHierarchyModel> GroupChildren { get; set; }

        [JsonProperty("groupEntities")]
        public List<GroupEntity> GroupEntities { get; set; }

        [JsonProperty("modifiedby")]
        public object Modifiedby { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }

    public class CurrentGroup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }

        [JsonProperty("groupType")]
        public GroupType GroupType { get; set; }

        [JsonProperty("modifiedby")]
        public object Modifiedby { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }

    public class GroupType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tenantId")]
        public object TenantId { get; set; }

        [JsonProperty("groupTypeDescription")]
        public string GroupTypeDescription { get; set; }

        [JsonProperty("modifiedBy")]
        public object ModifiedBy { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }

    public class GroupEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("GroupHierarchyId")]
        public object GroupHierarchyId { get; set; }

        [JsonProperty("GroupID")]
        public object GroupId { get; set; }

        [JsonProperty("EntityID")]
        public string EntityId { get; set; }

        [JsonProperty("EntityType")]
        public string EntityType { get; set; }
    }

}
