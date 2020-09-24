using Inseego.Utilities.Models;
using Serilog;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Threading.Tasks;

namespace Inseego.Utilities.CacheExtension
{
    public class Cache<T> : ICache<T> where T : class, new()
    {
        private readonly IRedisCacheClient _redisClient;
        private readonly bool _cachingDisabled;
        private readonly string _serviceRedisKey;

        public Cache(IRedisCacheClient redisClient)
        {
            _redisClient = redisClient;
            _cachingDisabled = Configuration.IsRedisDisabled;
            _serviceRedisKey = Configuration.ServiceRedisKey;
        }

        public async Task<T> GetCache(string key)
        {
            if (_cachingDisabled)
                return null;

            DateTime now = DateTime.Now;
            try
            {
                return await _redisClient.Db1.GetAsync<T>(_serviceRedisKey + key);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            finally
            {
                Log.Verbose($"Cache Get {(DateTime.Now - now).TotalSeconds}");
            }

            return null;
        }

        public async Task SetCache(string key, T value)
        {
            await SetCache(key, value, DateTime.Now + TimeSpan.FromDays(1));
        }

        public async Task SetCache(string key, T value, TimeSpan timespan)
        {
            await SetCache(key, value, DateTime.Now + timespan);
        }

        public async Task SetCache(string key, T value, DateTime expiryOptions)
        {
            if (_cachingDisabled)
                return;

            DateTime now = DateTime.Now;
            try
            {
                await _redisClient.Db1.AddAsync<T>(_serviceRedisKey + key, value, expiryOptions);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            finally
            {
                Log.Verbose($"Cache Set {(DateTime.Now - now).TotalSeconds}");
            }

            return;
        }
    }
}
