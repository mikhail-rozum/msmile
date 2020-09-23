namespace MSmile.Db.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implements Repository pattern.
    /// </summary>
    public sealed class Repository<TEntity>
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
        public void Add(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Adds set of entities to database.
        /// </summary>
        /// <param name="entities">Entities.</param>
        public void Add(IEnumerable<TEntity> entities)
        {
            this.dbContext.AddRange(entities);
        }

        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Update(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public void Delete(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Get <see cref="IQueryable{T}"/> collection of entities.
        /// </summary>
        /// <returns>Collection of entities.</returns>
        public IQueryable<TEntity> Get()
        {
            return this.dbContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// Saves changes.
        /// </summary>
        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
