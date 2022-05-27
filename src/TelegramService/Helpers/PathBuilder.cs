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

    /// <inheritdoc cref="PathBuilder" />
    public PathBuilder()
    {
        Path = new StringBuilder(ConfigKeys.BASE_URL);
    }

    /// <summary>
    ///     Добавляет копию строки к результирующей
    /// </summary>
    public PathBuilder Append(string partPath) 
    { 
        Path = Path.Append("/" + partPath); 
        return this;
    }

    /// <summary>
    ///     Получить в строковом виде
    /// </summary>
    public override string ToString() => Path.ToString();
}