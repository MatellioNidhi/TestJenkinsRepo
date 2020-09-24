using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Interface
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetData(string whereQuery, string partition);
    }
}
