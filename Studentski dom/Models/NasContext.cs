using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class NasContext : DbContext
    {
        public NasContext(DbContextOptions<NasContext> options) : base(options)
        {
        }

        public DbSet<PrijavaKvara> PrijavaKvara {get; set;}
        public DbSet<PrijavaObroka> PrijavaObroka { get; set; }
        public DbSet<PrijavaStudenta> PrijavaStudenta { get; set; }
        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<Soba> Soba { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<UposlenikDoma> UposlenikDoma { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrijavaKvara>().ToTable("PrijavaKvara");
            modelBuilder.Entity<PrijavaObroka>().ToTable("PrijavaObroka");
            modelBuilder.Entity<PrijavaStudenta>().ToTable("PrijavaStudenta");
            modelBuilder.Entity<Radnik>().ToTable("Radnik");
            modelBuilder.Entity<Soba>().ToTable("Soba");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<UposlenikDoma>().ToTable("UposlenikDoma");
        }

    }
}
