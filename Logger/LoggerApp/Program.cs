namespace LoggerApp;

using Microsoft.Extensions.Logging;

class Program
{
    public static void Main()
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning) // Filter system logs
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("AvevaApp", LogLevel.Debug) // Show your logs
                    .AddConsole();
            });

        var loggerClient = loggerFactory.CreateLogger("AvevaApp");

        // var custoFlagName = "helloFlag";

        int i =0;
        if (loggerClient != null)
        {
            while (i < 25)
            {
                // var isEnabled = loggerClient.IsCustomLogEnabled(custoFlagName);
                Console.WriteLine($"Current Value of 'i' is: {i}");
                Thread.Sleep(2000);
                i++;

                loggerClient.LogInformation($"logger message for the iter {i}");
            }
        }
        else
        {
            Console.WriteLine("Archestra Logger Not Installed.");
        }


    }
}