using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramService.Orioks;

namespace TelegramService.Telegram;

/// <summary>
///     Расширение обработчика обновлений
/// </summary>
internal sealed class UpdateHandler : IUpdateHandler
{
    /// <summary>
    ///     Обработка ошибки
    /// </summary>
    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }

    /// <summary>
    ///     Обработка удачно принятого сообщения
    /// </summary>
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type != UpdateType.Message)
            return;
        if (update.Message!.Type != MessageType.Text)
            return;

        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text;

        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

        var orioks = new OrioksClient();
        var response = await orioks.GetEmptyAuditoriesAsync();

        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"ВСЕГО АУДИТОРИЙ СВОБОДНО НА {response?.Pair} - {response?.Total} ШТУК:\n\n" + string.Join("\n",response!.Items),
            cancellationToken: cancellationToken);
    }
}
