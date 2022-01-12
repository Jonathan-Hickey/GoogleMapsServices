using System.Text.Json;
using O9d.Json.Formatting;

namespace GoogleMapsServices.Client.Serialization.SystemTextJson
{
    public class JsonSerialization : IJsonSerialization
    {
        private readonly JsonSerializerOptions _serializeOptions;

        public JsonSerialization()
        {
            _serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
                WriteIndented = true
            };
        }
        public string SerializerToSnakeCase(object obj)
        {
            return JsonSerializer.Serialize(obj, _serializeOptions);
        }

        public T? DeserializeFromSnakeCase<T>(string input)
        {
            return JsonSerializer.Deserialize<T>(input, _serializeOptions);
        }

        public async ValueTask<T?> DeserializeFromSnakeCase<T>(Stream input)
        {
            return await JsonSerializer.DeserializeAsync<T>(input, _serializeOptions);
        }
    }
}