using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface INotesService : IService<Notes>
    {
        void AtualizarNotes(Notes notes);
        IEnumerable<Notes> ObterPorUsuario(Guid usuarioId);
    }
}
