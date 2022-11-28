using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class NotesService : Service<Notes>, INotesService
    {
        private readonly INotesRepository _notesRepository;
        public NotesService(INotesRepository repository) : base(repository)
        {
            _notesRepository = repository;
        }

        public void AtualizarNotes(Notes notes)
        {
            var antigoNotes = _notesRepository.ObterPorId(notes.Id);
            antigoNotes.Atualizar(notes);
            return;
        }

        public IEnumerable<Notes> ObterPorUsuario(Guid usuarioId)
        {
            return _notesRepository.ObterPorUsuario(usuarioId);
        }
    }
}

