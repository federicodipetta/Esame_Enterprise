using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Entities.Categoria>

    {
        public void Configure(EntityTypeBuilder<Entities.Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(k => k.nome);
        }
    }
}
