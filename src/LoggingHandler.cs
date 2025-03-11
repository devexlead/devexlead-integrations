using System.Text.Json;

public class LoggingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Content!=null)
        {
            var requestLogFilePath = Path.Combine(AppContext.BaseDirectory, "Logs", $"Request_{DateTime.Now:yyyyMMddHHmmssfff}.json");
            await File.WriteAllTextAsync(requestLogFilePath, JsonSerializer.Serialize(request.Content.ReadAsStringAsync(), new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine($"Request log saved to: {requestLogFilePath}");
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.Content!=null)
        {
            var logDirectory = Path.Combine(AppContext.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            var responseLogFilePath = Path.Combine(logDirectory, $"Response_{DateTime.Now:yyyyMMddHHmmssfff}.json");
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(responseContent), new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(responseLogFilePath, responseJson);
            Console.WriteLine($"Response log saved to: {responseLogFilePath}");
        }

        return response;
    }
}
