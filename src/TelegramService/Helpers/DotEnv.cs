namespace TelegramService;

internal static class DotEnv
{
    public static void Load(string filePath = ConfigKeys.EnvPath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Environment file not found on path {Path.GetFullPath(filePath)}", "local.env");

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}
