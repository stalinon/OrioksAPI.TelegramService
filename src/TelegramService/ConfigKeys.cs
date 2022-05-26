using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TelegramService.Tests")]

namespace TelegramService;

/// <summary>
///     Ключи конфигурации
/// </summary>
internal sealed class ConfigKeys
{
    /// <summary>
    ///     Путь к .env файлу
    /// </summary>
    public const string EnvPath = "../../../../../local.env";

    /// <summary>
    ///     Токен Telegram бота
    /// </summary>
    public static readonly string API_TOKEN = Environment.GetEnvironmentVariable(nameof(API_TOKEN))!;

    /// <summary>
    ///     URL API OrioksServer
    /// </summary>
    public static readonly string BASE_URL = Environment.GetEnvironmentVariable(nameof(BASE_URL))!;
}