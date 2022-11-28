using uNotes.Application.Requests.Notes;
using uNotes.Application.Responses.Notes;
using uNotes.Domain.Entidades;

namespace uNotes.Application.AppService.Interface
{
    public interface INotesAppService
    {
        NotesAdicionarRequest Adicionar(NotesAdicionarRequest user);
        string Atualizar(NotesAtualizarRequest user);
        string RemoverLogica(Guid id);
        IEnumerable<NotesObterResponse> ObterTodos();
        NotesObterResponse ObterPorId(Guid id);
        IEnumerable<NotesObterResponse> ObterPorUsuario(Guid usuarioId);
        IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId);
        IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId);
    }
}
