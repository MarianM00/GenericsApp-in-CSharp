using System.Text.Json;

namespace GenericsApp.Entities
{
    public static class EntitiesExtensions
    {
        public static T?  Copy<T>(this T itemToCopy) where T : IEntityBase
        {
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
