namespace MSmile.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FluentValidation.AspNetCore;

    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Dto.Validators;
    using MSmile.Services.DataServices;
    using MSmile.Services.Mapper;

    using Z.BulkOperations.Internal;

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
            var profilesTypes = GetNonGenericDerivatives(typeof(MapperProfileBase));
            var mapperConfig = new MapperConfiguration(
                mc =>
                {
                    foreach (var profilesType in profilesTypes)
                    {
                        mc.AddProfile(profilesType);
                    }
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
            var servicesTypes = GetGenericDerivatives(typeof(BaseCrudService<,>));
            foreach (var serviceType in servicesTypes)
            {
                services.AddTransient(serviceType);
            }
        }

        private static List<Type> GetGenericDerivatives(Type genericBaseType)
        {
            return genericBaseType
                .GetAssemblyCore()
                .GetTypes()
                .Where(x =>
                    x.IsClass
                    && !x.IsAbstract
                    && x.BaseType != null
                    && x.BaseType.IsGenericType
                    && x.BaseType.GetGenericTypeDefinition() == genericBaseType)
                .ToList();
        }

        private static List<Type> GetNonGenericDerivatives(Type baseType)
        {
            return baseType
                .GetAssemblyCore()
                .GetTypes()
                .Where(x =>
                    x.IsClass
                    && !x.IsAbstract
                    && x.BaseType != null
                    && x.IsAssignableTo(typeof(MapperProfileBase)))
                .ToList();
        }
    }
}
