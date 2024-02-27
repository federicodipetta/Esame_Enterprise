using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Configurations
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Entities.Utente>
    {
        public void Configure(EntityTypeBuilder<Entities.Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(k => k.id);
            builder.Property(k => k.id).ValueGeneratedOnAdd();
            
        }
    }
   
}
