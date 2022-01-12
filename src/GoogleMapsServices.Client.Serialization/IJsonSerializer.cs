namespace GoogleMapsServices.Client.Serialization
{
    public interface IJsonSerialization
    {
        string SerializerToSnakeCase(Object obj);
        T? DeserializeFromSnakeCase<T>(string input);
        ValueTask<T?> DeserializeFromSnakeCase<T>(Stream input);
    }
}