namespace MSmile.Db.Infrastructure
{
    using System;

    /// <summary>
    /// Implements Repository pattern.
    /// </summary>
    public class Repository<TEntity> : IDisposable
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

        /// <summary>
        /// Adds entity to database
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async void AddAsync(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
        }

        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public virtual void Delete(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        /// <inheritdoc />
        public virtual async void Dispose()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
