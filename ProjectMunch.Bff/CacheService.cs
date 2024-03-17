using System.Text.Json;
using StackExchange.Redis;

namespace ProjectMunch.Bff
{
    public interface ICacheService
    {
        T? GetData<T>(string key);
        bool SetData<T>(string key, T value);
        bool RemoveData(string key);
    }

    public class CacheService(IConnectionMultiplexer muxer) : ICacheService
    {
        private readonly IDatabase _db = muxer.GetDatabase();

        public T? GetData<T>(string key)
        {
            var value = _db.StringGet(key);

            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value!)!;
            }

            return default;
        }

        public bool RemoveData(string key)
        {
            bool existing = _db.KeyExists(key);

            if (existing)
            {
                return _db.KeyDelete(key);
            }

            return false;
        }

        public bool SetData<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);

            var isSet = _db.StringSet(key, serializedValue);

            return isSet;
        }
    }
}
