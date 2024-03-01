using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Configurations
{
    public class AutoreConfiguration : IEntityTypeConfiguration<Entities.Autore>

    {
        public void Configure(EntityTypeBuilder<Entities.Autore> builder)
        {
            builder.ToTable("Autore");
            builder.HasKey(k => k.nome);
        }
    }
}
