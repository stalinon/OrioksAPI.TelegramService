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
    private CancellationTokenSource _cts = new CancellationTokenSource();
    private static TgClient _instance { get; set; } = default!;

    /// <inheritdoc />
    public static async Task<TgClient> CreateInstance()
    {
        var instance = new TgClient();

        var options = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };
        instance._client.StartReceiving(new UpdateHandler(), options, instance._cts.Token);

        var me = await instance._client.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();
        instance._cts.Cancel();

        _instance = instance;

        return _instance;
    }

    private TgClient() { }
}
