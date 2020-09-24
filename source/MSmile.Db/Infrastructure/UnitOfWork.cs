namespace MSmile.Db.Infrastructure
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
            this.DifficultyLevelRepository = new Repository<DifficultyLevel>(this.dbContext);
            this.EmployeeRepository = new Repository<Employee>(this.dbContext);
            this.PupilRepository = new Repository<Pupil>(this.dbContext);
            this.ParentRepository = new Repository<Parent>(this.dbContext);
        }

        /// <summary>
        /// Parent repository.
        /// </summary>
        public Repository<Parent> ParentRepository { get; }

        /// <summary>
        /// Pupil repository.
        /// </summary>
        public Repository<Pupil> PupilRepository { get; }

        /// <summary>
        /// Skills repository.
        /// </summary>
        public Repository<Skill> SkillRepository { get; }

        /// <summary>
        /// Difficulty level repository.
        /// </summary>
        public Repository<DifficultyLevel> DifficultyLevelRepository { get; }

        /// <summary>
        /// Employee repository.
        /// </summary>
        public Repository<Employee> EmployeeRepository { get; }

        /// <summary>
        /// Returns repository.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Repository</returns>
        public Repository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity
        {
            return new Repository<TEntity>(this.dbContext);
        }

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
