using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Utilities.CacheExtension
{
    public interface ICache<T> where T : class
    {
        Task<T> GetCache(string key);
        Task SetCache(string key, T value);
        Task SetCache(string key, T value, TimeSpan timeToLive);
    }
}
