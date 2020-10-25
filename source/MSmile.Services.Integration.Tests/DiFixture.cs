namespace MSmile.Services.Integration.Tests
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Api;
    using MSmile.Db.Extensions;

    /// <summary>
    /// Fixture for dependency injection.
    /// </summary>
    public class DiFixture
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public DiFixture()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();
            services.AddAutoMapper();
            services.AddDataServices();
            services.AddDatabase(this.Configuration);
            this.ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Service provider.
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }
    }
}
