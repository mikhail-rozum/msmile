namespace MSmile.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        private const string EnvironmentPrefix = "MSmile_";

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates host.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (context, builder) =>
                    {
                        builder.AddEnvironmentVariables(EnvironmentPrefix);

                        if (context.HostingEnvironment.IsDevelopment())
                        {
                            builder.AddUserSecrets<Program>();
                        }
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
