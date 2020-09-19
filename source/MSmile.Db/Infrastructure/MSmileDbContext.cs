namespace MSmile.Db.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using MSmile.Db.Entities;

    /// <inheritdoc />
    public partial class MSmileDbContext : DbContext
    {
        /// <inheritdoc />
        public MSmileDbContext()
        {
        }

        /// <inheritdoc />
        public MSmileDbContext(DbContextOptions<MSmileDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Test.
        /// </summary>
        public virtual DbSet<Test> Test { get; set; }

        /// <summary>
        /// Versions.
        /// </summary>
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=MSmileDb");
            }
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasComment("Test table");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<VersionInfo>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Version)
                    .HasName("UC_Version")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1024);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
