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
            return _notesRepository.ObterPorUsuarioTodos(usuarioId);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId)
        {
            return _notesRepository.ObterPorUsuarioArquivado(usuarioId);
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId)
        {
            return _notesRepository.ObterPorUsuarioLixeira(usuarioId);
        }

        public string RemoverLogica(Guid notaId)
        {
            var nota = _notesRepository.ObterPorId(notaId);
            if (nota == null)
                return "Nota não encontrada";
            nota.RemoverLogica();
            return "Nota removida com sucesso";
        }
    }
}

