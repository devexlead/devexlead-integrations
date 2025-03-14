using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DevExLead.Integrations
{
    public static class RefitHelper
    {
        public static RefitSettings GetSettings(bool isVerbose)
        {
            var refitSettings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                    Converters = { new IntegrationsCommon.JsonConverters.DateTimeConverter() }
                }),
            };

            if (isVerbose)
            {
                refitSettings.HttpMessageHandlerFactory = () => new LoggingHandler { InnerHandler = new HttpClientHandler() };
            }

            return refitSettings;
        }
    }
}
