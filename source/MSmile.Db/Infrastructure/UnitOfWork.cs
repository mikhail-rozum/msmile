﻿namespace MSmile.Db.Infrastructure
{
    using System;

    using MSmile.Db.Entities;

    /// <summary>
    /// Unit of work pattern.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private readonly MSmileDbContext dbContext;

        /// <summary>
        /// ctor.
        /// </summary>
        public UnitOfWork(MSmileDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.SkillRepository = new Repository<Skill>(this.dbContext);
        }

        /// <summary>
        /// Skills repository.
        /// </summary>
        public Repository<Skill> SkillRepository { get; }

        /// <summary>
        /// Saves all the changes.
        /// </summary>
        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
