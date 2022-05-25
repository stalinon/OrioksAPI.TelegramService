namespace TelegramService;

/// <summary>
///     Ключи конфигурации
/// </summary>
internal sealed class ConfigKeys
{
    /// <summary>
    ///     Путь к .env файлу
    /// </summary>
    public static readonly string EnvPath = "../../../../../local.env";

    public static readonly string API_TOKEN = Environment.GetEnvironmentVariable(nameof(API_TOKEN))!;
}