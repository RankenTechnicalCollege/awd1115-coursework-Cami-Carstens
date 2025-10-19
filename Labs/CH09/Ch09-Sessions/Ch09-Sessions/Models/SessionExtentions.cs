using System.Text.Json;

namespace Ch09_Sessions.Models
{
    public static class SessionExtentions
    {
        //Set Object
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value)); 
        }

        //Get Object
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
