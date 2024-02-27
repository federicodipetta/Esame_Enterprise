using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Configurations
{
    public class RecensioneConfiguration : IEntityTypeConfiguration<Entities.Recensione>
    {
        public void Configure(EntityTypeBuilder<Entities.Recensione> builder)
        {
            builder.ToTable("Recensione");
            builder.HasKey(k => new { k.idLibro, k.idUtente });
            builder.HasOne(f => f.libro).WithMany().HasForeignKey(f => f.idLibro);
            builder.HasOne(f => f.utente).WithMany().HasForeignKey(f => f.idUtente);
            builder.Property(x => x.stato).HasConversion<int>();
        }
    }



}
