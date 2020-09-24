namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Db.Infrastructure;

    /// <summary>
    /// Base service class
    /// </summary>
    public abstract class BaseService
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        /// <param name="serviceProvider">Service provider.</param>
        protected BaseService(IMapper mapper, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Execute a delegate in DB, and returns result.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="func">Func.</param>
        /// <returns>Result.</returns>
        protected T ExecuteInDb<T>(Func<UnitOfWork, T> func)
        {
            using (var scope = this.serviceProvider.CreateScope())
            using (var uow = scope.ServiceProvider.GetService<UnitOfWork>())
            {
                var result = func(uow);
                uow.Save();
                return result;
            }
        }

        /// <summary>
        /// Execute a delegate in DB.
        /// </summary>
        /// <param name="action">Action.</param>
        protected void ExecuteInDb(Action<UnitOfWork> action)
        {
            using (var scope = this.serviceProvider.CreateScope())
            using (var uow = scope.ServiceProvider.GetService<UnitOfWork>())
            {
                action(uow);
                uow.Save();
            }
        }

        /// <summary>
        /// Mapper.
        /// </summary>
        protected IMapper Mapper { get; }
    }
}
