using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class UsuarioGrupoMapping : IEntityTypeConfiguration<UsuarioGrupo>
    {
        public void Configure(EntityTypeBuilder<UsuarioGrupo> builder)
        {
            builder.ToTable(Tabelas.UsuarioGrupo);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.GrupoId).IsRequired();

            builder.HasOne(x => x.Grupo)
                .WithMany(x => x.Vinculos);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Grupos);
        }
    }
}
