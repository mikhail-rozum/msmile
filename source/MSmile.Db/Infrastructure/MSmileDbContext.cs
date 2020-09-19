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

        public virtual DbSet<DifficultyLevel> DifficultyLevel { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonTask> LessonTask { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<ParentContact> ParentContact { get; set; }
        public virtual DbSet<Pupil> Pupil { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskSkill> TaskSkill { get; set; }
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
            modelBuilder.Entity<DifficultyLevel>(entity =>
            {
                entity.HasComment("Complexity Levels");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

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

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasComment("Lessons");

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_EmployeeId_Employee_Id");

                entity.HasOne(d => d.Pupil)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.PupilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_PupilId_Pupil_Id");
            });

            modelBuilder.Entity<LessonTask>(entity =>
            {
                entity.HasKey(e => new { e.LessonId, e.TaskId });

                entity.HasComment("Link between Lessons and Tasks");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonTask)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonTask_LessonId_Lesson_Id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.LessonTask)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonTask_TaskId_Task_Id");
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

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasComment("Skills");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasComment("Tasks");

                entity.Property(e => e.CustomerDescription)
                    .HasMaxLength(1000)
                    .HasComment("Description only for parents");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasComment("Description for employees");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.DifficultyLevel)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.DifficultyLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_DifficultyLevelId_DifficultyLevel_Id");
            });

            modelBuilder.Entity<TaskSkill>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.SkillId });

                entity.HasComment("Link between Tasks and Skills");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TaskSkill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskSkill_SkillId_Skill_Id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskSkill)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskSkill_TaskId_Task_Id");
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
