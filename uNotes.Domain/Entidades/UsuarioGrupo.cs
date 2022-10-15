
namespace uNotes.Domain.Entidades
{
    public class UsuarioGrupo : EntidadeBase
    {
        public Guid UsuarioId { get; set; }
        public Guid GrupoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
