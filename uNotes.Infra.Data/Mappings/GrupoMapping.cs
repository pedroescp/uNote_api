using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class GrupoMapping : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable(Tabelas.Grupo);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();

            builder.HasMany(x => x.Vinculos)
                .WithOne(x => x.Grupo);
        }
    }
}
