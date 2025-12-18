namespace LoggerApp;

using System.Security.Principal;
using Microsoft.Extensions.Logging;
using AvevaApp;

class Program
{

    private static readonly string LoggerDllPath = GetLoggerDllPath();

    private static int identity = 0;
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

        int i =24;
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

        
        AAInitialize();

        i=100;
        while (i < 125)
        {
            Console.WriteLine($"Current Value of 'i' is: {i}");
            Thread.Sleep(2000);
            i++;

            NativeMethods.LogInfo(identity, $"logger message for the iter {i}");
        }

    }

    private static string GetLoggerDllPath()
        {
            // If your target is x86, then both Environment.SpecialFolder.ProgramFiles and Environment.SpecialFolder.ProgramFilesX86 will return the same path
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86), @"ArchestrA\LoggerDll.dll");
        }

    private static void AAInitialize()
    {
        var mh = 0;
        Console.WriteLine($"LoggerDllPath {LoggerDllPath}");
        NativeMethods.LoadLibraryW(LoggerDllPath);
        var rc = NativeMethods.RegisterLoggerClient(ref mh);
        identity = mh;

        NativeMethods.SetIdentityName(identity, "AvevaAppAALogger");
    }
}