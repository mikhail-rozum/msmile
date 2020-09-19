namespace MSmile.Db.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database context
    /// </summary>
    public class MSmileDbContext : DbContext
    {
        /// <inheritdoc />
        public MSmileDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
