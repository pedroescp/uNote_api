using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface INotesRepository : IRepository<Notes>
    {
        IEnumerable<Notes> ObterPorUsuarioTodos(Guid usuarioId);
        IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId);
        IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId);
    }
}
