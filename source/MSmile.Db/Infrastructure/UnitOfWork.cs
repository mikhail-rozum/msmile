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
        }

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
