namespace MSmile.Api
{
    using AutoMapper;

    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Services.Mapper;

    /// <summary>
    /// Extensions for starting up
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Register all needed classes for AutoMapper.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfile<DictionariesMapperProfile>();
                });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
