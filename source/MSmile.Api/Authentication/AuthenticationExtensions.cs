namespace MSmile.Api.Authentication
{
    using System.Text;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Authentication extensions.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Configures application authentication.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection(nameof(JwtTokenConfiguration)).Get<JwtTokenConfiguration>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfiguration.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtConfiguration.Secret.GetSymmetricSecurityKey()
                    };
                });

            services.AddTransient<AuthenticationService>();
        }

        /// <summary>
        /// Returns symmetric security key from a secret string..
        /// </summary>
        /// <param name="secret">Secret string.</param>
        /// <returns>Security key.</returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey(this string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
