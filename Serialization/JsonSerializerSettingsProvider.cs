using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ClimateMeter.Web.Serialization
{
    public static class JsonSerializerSettingsProvider
    {
        public static JsonSerializerSettings CreateSettings()
        {
            var settings = new JsonSerializerSettings();
            
            SetSettings(settings);
            
            return settings;
        }

        public static void SetSettings(JsonSerializerSettings settings)
        {
            settings.NullValueHandling = NullValueHandling.Include;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.TypeNameHandling = TypeNameHandling.None;
        }
    }
}