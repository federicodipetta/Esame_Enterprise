using Libri_application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Context
{
    public class MyDbContext : DbContext
    {

        public DbSet<Libro> Libro { get; set; }
        public DbSet<Utente> Utente { get; set; }

       public DbSet<Recensione> Recensione { get; set; }

        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=LibriApplication;User Id=manager;Password=a;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(optionsBuilder);
        }

    }
}
