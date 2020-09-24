using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Interface
{
    public interface ICTRIndexFinalRepository
    {
        Task<List<ConsolidatedTripRecord>> GetData(string whereQuery, string partition);
    }
}
