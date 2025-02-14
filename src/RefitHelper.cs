using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace DevEx.Integrations
{
    public static class RefitHelper
    {
        public static RefitSettings GetSettings()
        {
            return new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                    Converters = { new IntegrationsCommon.JsonConverters.DateTimeConverter() }
                }),
                HttpMessageHandlerFactory = () => new LoggingHandler { InnerHandler = new HttpClientHandler() }
            };
        }
    }
}
