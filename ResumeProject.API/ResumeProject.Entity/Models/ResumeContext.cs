using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class ResumeContext : DbContext
    {
        public ResumeContext()
        {
        }

        public ResumeContext(DbContextOptions<ResumeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BM5NO11;Database=Resume;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.CertificateUrl).HasMaxLength(250);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Certificate_Skill");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.School)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.Degree).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.ToTable("LoginUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.CertificateUrl)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RepoUrl)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Skill");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.TechnologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Technology");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.ToTable("Technology");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.GithubUrl)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.LinkedInUrl)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Preference)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.ToTable("WorkExperience");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.WorkExperiences)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkExperience_Skill");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.WorkExperiences)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkExperience_Task");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
