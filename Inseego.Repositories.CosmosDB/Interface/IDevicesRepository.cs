using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Interface
{
    public interface IDevicesRepository
    {
        Task<List<Devices>> GetData(string whereQuery, string partition);
    }
}
