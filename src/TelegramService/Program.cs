using TelegramService;
using TelegramService.Telegram;

static Task StartApplication(CancellationTokenSource cts)
{
    var keepRunning = true;

    var client = TgClient.CreateInstance(cts.Token);

    Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
        keepRunning = false;
    };

    while (keepRunning)
    { }
    Console.WriteLine("exited");
    return Task.CompletedTask;
}

DotEnv.Load();
var cts = new CancellationTokenSource();

await StartApplication(cts);