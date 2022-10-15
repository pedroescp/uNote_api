using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface IGrupoRepository : IRepository<Grupo>
    {
        IEnumerable<Grupo> ObterGrupos();
    }
}
