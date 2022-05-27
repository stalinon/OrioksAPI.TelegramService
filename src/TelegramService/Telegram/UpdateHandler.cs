using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramService.Orioks;

namespace TelegramService.Telegram;

/// <summary>
///     Расширение обработчика обновлений
/// </summary>
internal sealed class UpdateHandler : IUpdateHandler
{
    private readonly OrioksClient _client = new OrioksClient();

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

        Console.WriteLine($"Get message::{chatId}::{messageText}");

        var message = await AnalyzeMessageAsync(botClient, messageText);

        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message.Text,
                replyMarkup: message.ReplyMarkup ?? null,
                cancellationToken: cancellationToken);
    }

    private async Task<CustomMessage> AnalyzeMessageAsync(ITelegramBotClient botClient, string? text)
    {
        if (text == ButtonTextEnumMapping.Map(ButtonScheduleEnum.GET_EMPTY_AUDITORIES))
        {
            var auditories = await _client.GetEmptyAuditoriesAsync();
            var orderedAuditories = auditories.Items.OrderBy(x => x);

            var str = $"СПИСОК ПУСТЫХ АУДИТОРИЙ НА `{auditories.Pair}` \n" +
                      $"Количество: {auditories.Total} \n";
            foreach (var item in orderedAuditories)
            {
                str += "\t" + item.ToString() + "\n";
            }

            return new CustomMessage
            {
                Text = str
            };

        }
        else
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { ButtonTextEnumMapping.Map(ButtonScheduleEnum.GET_EMPTY_AUDITORIES) }
            })
            {
                ResizeKeyboard = true
            };

            return new CustomMessage
            {
                Text = "Выберите опцию",
                ReplyMarkup = replyKeyboardMarkup
            };
        }
    }

    /// <summary>
    ///     Вспомогательный подкласс для возврата
    ///     сообщения
    /// </summary>
    class CustomMessage
    {
        /// <summary>
        ///     Текст сообщения
        /// </summary>
        public string Text { get; set; } = "Выберай";

        /// <summary>
        ///     Reply Markup
        /// </summary>
        public IReplyMarkup? ReplyMarkup { get; set; }
    }
}
