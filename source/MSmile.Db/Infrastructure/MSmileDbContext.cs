using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MSmile.Db.Entities;

#nullable disable

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

        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseSkill> ExerciseSkills { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ParentContact> ParentContacts { get; set; }
        public virtual DbSet<ParentPupil> ParentPupils { get; set; }
        public virtual DbSet<Pupil> Pupils { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VersionInfo> VersionInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=MSmileDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<DifficultyLevel>(entity =>
            {
                entity.ToTable("DifficultyLevel");

                entity.HasComment("Complexity Levels");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

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

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("Exercise");

                entity.HasComment("Tasks");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Task_Id_seq\"'::regclass)");

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
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.DifficultyLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_DifficultyLevelId_DifficultyLevel_Id");
            });

            modelBuilder.Entity<ExerciseSkill>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.SkillId })
                    .HasName("PK_TaskSkill");

                entity.ToTable("ExerciseSkill");

                entity.HasComment("Link between Tasks and Skills");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ExerciseSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskSkill_SkillId_Skill_Id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.ExerciseSkills)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskSkill_TaskId_Task_Id");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.HasComment("Lessons");

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_EmployeeId_Employee_Id");

                entity.HasOne(d => d.Pupil)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.PupilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_PupilId_Pupil_Id");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

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
                entity.ToTable("ParentContact");

                entity.HasComment("ParentContacts");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentContacts)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentContact_ParentId_Parent_Id");
            });

            modelBuilder.Entity<ParentPupil>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.PupilId });

                entity.ToTable("ParentPupil");

                entity.HasComment("Link between Parents and Pupils");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentPupils)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentPupil_ParentId_Parent_Id");

                entity.HasOne(d => d.Pupil)
                    .WithMany(p => p.ParentPupils)
                    .HasForeignKey(d => d.PupilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentPupil_PupilId_Pupil_Id");
            });

            modelBuilder.Entity<Pupil>(entity =>
            {
                entity.ToTable("Pupil");

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
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.HasComment("Skills");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test");

                entity.HasComment("Test table");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasComment("Users");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_EmployeeId_Employee_Id");
            });

            modelBuilder.Entity<VersionInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VersionInfo");

                entity.HasIndex(e => e.Version, "UC_Version")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1024);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
