namespace MSmile.Db.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Z.EntityFramework.Plus;

    /// <summary>
    /// Implements Repository pattern.
    /// </summary>
    public sealed class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly MSmileDbContext dbContext;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        public Repository(MSmileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc />
        public Task AddAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
            return this.dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task AddAsync(IEnumerable<TEntity> entities)
        {
            this.dbContext.Set<TEntity>().AddRange(entities);
            return this.dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
            return this.dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            this.dbContext.Set<TEntity>().Where(filter).Delete();
            return this.dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public IQueryable<TEntity> Get()
        {
            return this.dbContext.Set<TEntity>();
        }

        /// <inheritdoc />
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return this.Get().Where(filter);
        }

        /// <inheritdoc />
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this.Get(filter).FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this.Get(filter).FirstAsync();
        }

        /// <inheritdoc />
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this.Get(filter).SingleOrDefaultAsync();
        }

        /// <inheritdoc />
        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this.Get(filter).SingleAsync();
        }

        /// <inheritdoc />
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this.Get(filter).AnyAsync();
        }

        /// <inheritdoc />
        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }
    }
}
