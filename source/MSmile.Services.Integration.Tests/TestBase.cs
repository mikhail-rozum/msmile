namespace MSmile.Services.Integration.Tests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using MSmile.Db.Infrastructure;

    using Xunit;

    /// <summary>
    /// Base class for all the tests.
    /// </summary>
    public abstract class TestBase<TService> : IClassFixture<DiFixture>
        where TService : class
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="diFixture">DI fixture.</param>
        protected TestBase(DiFixture diFixture)
        {
            this.DiFixture = diFixture;
        }

        /// <summary>
        /// DI fixture.
        /// </summary>
        protected DiFixture DiFixture { get; }

        /// <summary>
        /// Executes test's body.
        /// </summary>
        /// <param name="action">Action.</param>
        protected async Task ExecuteTest(Func<MSmileDbContext, TService, Task> action)
        {
            var context = this.DiFixture.ServiceProvider.GetService<MSmileDbContext>();
            var service = this.DiFixture.ServiceProvider.GetService<TService>();
            var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                await action(context, service);
            }
            finally
            {
                await transaction.RollbackAsync();
            }
        }
    }
}
