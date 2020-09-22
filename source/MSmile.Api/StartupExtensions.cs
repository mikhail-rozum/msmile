namespace MSmile.Api
{
    using AutoMapper;

    using FluentValidation.AspNetCore;

    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Dto.Validators;
    using MSmile.Services;
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

        /// <summary>
        /// Registers all needed classes for FluentValidator
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddFluentValidator(this IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidatorBase>());
        }

        /// <summary>
        /// Registers all the data services.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<SkillService>();
            services.AddTransient<DifficultyLevelService>();
            services.AddTransient<EmployeeService>();
        }
    }
}
