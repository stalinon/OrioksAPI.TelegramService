using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TelegramService.Orioks;

/// <summary>
///     Клиент для работы с API OrioksServer
/// </summary>
internal sealed class OrioksClient
{
    private readonly RestClient _client;

    /// <inheritdoc />
    public OrioksClient()
    {
        _client = new RestClient(new HttpClientHandler
        {
            CookieContainer = new System.Net.CookieContainer(),
            UseCookies = true,
        });
    }

    /// <summary>
    ///     Получить пустые аудитории
    /// </summary>
    public async Task<Response?> GetEmptyAuditoriesAsync()
    {
        var uri = new PathBuilder().Append(ConfigKeys.VERSION).Append("schedules").Append("empty-auditories").ToString();

        var request = new RestRequest
        {
            Resource = uri,
            Method = Method.Get
        };

        var response = await _client.GetAsync<Response>(request);

        return response;

    }

    public class Response
    {
        [JsonPropertyName("pair")]
        public string Pair { get; set; } = default!;

        [JsonPropertyName("items")]
        public string[] Items { get; set; } = Array.Empty<string>();

        [JsonPropertyName("total")]
        public long Total { get; set; } = 0;
    }
}
