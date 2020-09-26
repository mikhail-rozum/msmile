namespace MSmile.Api
{
    using System.IO;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (context, builder) =>
                    {
                        builder.AddEnvironmentVariables();
                    })
                .ConfigureLogging(
                    (context, builder) =>
                    {
                        builder.ClearProviders();
                        builder.AddConsole();

                        var logFileTemplate = context.Configuration.GetValue<string>("LogSettings:Path");
                        builder.AddFile(logFileTemplate);
                    })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
