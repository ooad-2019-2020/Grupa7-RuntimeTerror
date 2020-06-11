using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreAPI
{
    public partial class StudentskidomContext : DbContext
    {
        public StudentskidomContext()
        {
        }

        public StudentskidomContext(DbContextOptions<StudentskidomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<PrijavaKvara> PrijavaKvara { get; set; }
        public virtual DbSet<PrijavaObroka> PrijavaObroka { get; set; }
        public virtual DbSet<PrijavaStudenta> PrijavaStudenta { get; set; }
        public virtual DbSet<Radnik> Radnik { get; set; }
        public virtual DbSet<Soba> Soba { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<UposlenikDoma> UposlenikDoma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:runtimeterror.database.windows.net,1433;Initial Catalog=Studentski dom;Persist Security Info=False;User ID=dzenesma;Password=Sifrazaooad1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<PrijavaKvara>(entity =>
            {
                entity.HasIndex(e => e.StudentId);

                entity.Property(e => e.PrijavaKvaraId).HasColumnName("PrijavaKvaraID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("createdByUserId");

                entity.Property(e => e.Rijeseno)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PrijavaKvara)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<PrijavaObroka>(entity =>
            {
                entity.HasIndex(e => e.StudentId);

                entity.Property(e => e.PrijavaObrokaId).HasColumnName("PrijavaObrokaID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("createdByUserId");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PrijavaObroka)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<PrijavaStudenta>(entity =>
            {
                entity.Property(e => e.PrijavaStudentaId).HasColumnName("PrijavaStudentaID");

                entity.Property(e => e.Jmbg).HasColumnName("JMBG");
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.HasIndex(e => e.UposlenikDomaId);

                entity.Property(e => e.RadnikId).HasColumnName("RadnikID");

                entity.Property(e => e.UposlenikDomaId).HasColumnName("UposlenikDomaID");

                entity.Property(e => e.UposlenikId).HasColumnName("UposlenikID");

                entity.HasOne(d => d.UposlenikDoma)
                    .WithMany(p => p.Radnik)
                    .HasForeignKey(d => d.UposlenikDomaId);
            });

            modelBuilder.Entity<Soba>(entity =>
            {
                entity.Property(e => e.SobaId).HasColumnName("SobaID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.PrijavaStudentaId);

                entity.HasIndex(e => e.SobaId);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.PrijavaStudentaId).HasColumnName("PrijavaStudentaID");

                entity.Property(e => e.SobaId).HasColumnName("SobaID");

                entity.HasOne(d => d.PrijavaStudenta)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.PrijavaStudentaId);

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.SobaId);
            });

            modelBuilder.Entity<UposlenikDoma>(entity =>
            {
                entity.Property(e => e.UposlenikDomaId).HasColumnName("UposlenikDomaID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
