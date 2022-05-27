using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.Enums;

namespace TelegramService.Telegram;

/// <summary>
///     Кастомный клиент для связи с ботом в TG
/// </summary>
internal sealed class TgClient
{
    /// Поля, необходимые для работы клиента
    private TelegramBotClient _client = new TelegramBotClient(ConfigKeys.API_TOKEN);
    private static TgClient _instance { get; set; } = default!;

    /// <inheritdoc cref="TgClient" />
    public static TgClient CreateInstance(CancellationToken cts)
    {
        var instance = new TgClient();

        var options = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };
        instance._client.StartReceiving(new UpdateHandler(), options, cts);

        Console.WriteLine($"Start listening");

        _instance = instance;

        return _instance;
    }

    private TgClient() { }
}
