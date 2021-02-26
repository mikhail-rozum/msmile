namespace MSmile.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Api.Authentication;
    using MSmile.Db.Extensions;

    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures services.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtTokenConfiguration>(Configuration.GetSection(nameof(JwtTokenConfiguration)));

            services.ConfigureAuthentication(Configuration);
            services.AddDatabase(Configuration);
            services.AddMigrations(Configuration);
            services.AddAutoMapper();
            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddFluentValidator();
            services.AddDataServices();
            services.AddDataGenServices();
        }

        /// <summary>
        /// Configures application.
        /// </summary>
        /// <param name="app">Application.</param>
        /// <param name="env">Environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.ApplicationServices.UpdateDatabase();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
