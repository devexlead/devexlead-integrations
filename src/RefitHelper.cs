using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace  DevEx.Integrations
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
                    WriteIndented = true
                }),
                HttpMessageHandlerFactory = () => new LoggingHandler { InnerHandler = new HttpClientHandler() }
            };
        }
    }
}
