using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MSmile.Db.Entities;

namespace MSmile.Db.Infrastructure
{
    public partial class MSmileDbContext : DbContext
    {
        public MSmileDbContext()
        {
        }

        public MSmileDbContext(DbContextOptions<MSmileDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<ParentContact> ParentContact { get; set; }
        public virtual DbSet<Pupil> Pupil { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=MSmileDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasComment("Employee table");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Comment).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasComment("Parents");

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ParentContact>(entity =>
            {
                entity.HasComment("ParentContacts");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentContact)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentContact_ParentId_Parent_Id");
            });

            modelBuilder.Entity<Pupil>(entity =>
            {
                entity.HasComment("Pupils");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Pupil)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pupil_ParentId_Parent_Id");
            });

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
