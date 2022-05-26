using System.Text;

namespace TelegramService;

/// <summary>
///     Строитель путей API
/// </summary>
internal class PathBuilder
{
    /// <summary>
    ///     Результирующий путь
    /// </summary>
    private StringBuilder Path { get; set; }

    /// <inheritdoc />
    public PathBuilder()
    {
        Path = new StringBuilder(ConfigKeys.BASE_URL);
    }

    /// <summary>
    ///     Добавляет копию строки к результирующей
    /// </summary>
    public string Append(string partPath) => Path.Append("/" + partPath).ToString();

    /// <summary>
    ///     Получить в строковом виде
    /// </summary>
    public override string ToString() => Path.ToString();
}