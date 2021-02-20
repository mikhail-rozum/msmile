namespace MSmile.Db.Extensions
{
    using System;

    using FluentMigrator.Runner;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Db.Infrastructure;
    using MSmile.Db.Migrations;

    /// <summary>
    /// Startup extensions for database and migrations
    /// </summary>
    public static class StartupExtension
    {
        private const string ConnectionName = "MSmileDb";

        /// <summary>
        /// Register database dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MSmileDbContext>(options => options.UseNpgsql(configuration.GetConnectionString(ConnectionName)));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }

        /// <summary>
        /// Register migrations in DI.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddMigrations(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine(configuration.GetConnectionString(ConnectionName));
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb =>
                    rb.AddPostgres()
                      .WithGlobalConnectionString(configuration.GetConnectionString(ConnectionName))
                      .ScanIn(typeof(AddTestTable).Assembly)
                      .For
                      .Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        /// <summary>
        /// Applies migrations.
        /// </summary>
        /// <param name="serviceProvider">Service provider.</param>
        public static void UpdateDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }
    }
}
