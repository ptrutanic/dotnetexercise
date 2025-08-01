using System.Text.Json;

namespace AbySalto.Mid.Infrastructure.Configuration
{
    public static class JsonOptionsProvider
    {
        public static readonly JsonSerializerOptions DefaultOptions = new()
        {
            PropertyNameCaseInsensitive = true
            // Add more options here if needed (e.g., converters)
        };
    }
}