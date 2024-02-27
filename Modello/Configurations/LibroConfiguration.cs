using Libri_application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Entities.Libro>
    {
        public void Configure(EntityTypeBuilder<Entities.Libro> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(k => k.id);
            builder.HasMany(l => l.categorie).WithMany(c => c.libri).UsingEntity("CategoriaLibro");
        }
    }
}
