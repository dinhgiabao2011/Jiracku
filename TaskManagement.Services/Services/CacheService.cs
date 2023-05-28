using KPTMockProject.Common.Filter;
using StackExchange.Redis;
using System.Text.Json;
using TaskManagement.Services.DTOs;

namespace TaskManagement.Services.Services
{
    public class CacheService : ICacheService
    {
        IDatabase _cacheDb;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("redisstack");
            _cacheDb = redis.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var data = _cacheDb.StringGet(key);
            if (!string.IsNullOrEmpty(data))
            {
                return JsonSerializer.Deserialize<T>(data);
            }
            return default;
        }

        public (T, PaginationFilter, int) GetDataPagination<T>(string key)
        {
            var validFilter = new PaginationFilter();
            var count = 0;
            var data = _cacheDb.StringGet(key);
            if (!string.IsNullOrEmpty(data))
            {
                var convertData = JsonSerializer.Deserialize<T>(data);
                return (convertData,validFilter,count);
            }
            return default;
        }

        public object RemoveData<T>(string key)
        {
            var exist = _cacheDb.KeyExists(key);
            if (exist)
            {
                return _cacheDb.KeyDelete(key);
            }
            return false;
        }
        public bool SetData<T>(string key, T data, DateTimeOffset expirationTime)
        {
            var expireTime = expirationTime.DateTime.Subtract(DateTime.Now);
            return _cacheDb.StringSet(key, JsonSerializer.Serialize(data), expireTime);
        }
    }
}
