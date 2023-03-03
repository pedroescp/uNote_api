﻿using uNotes.Application.Requests.Notes;
using uNotes.Application.Responses.Notes;
using uNotes.Domain.Entidades;

namespace uNotes.Application.AppService.Interface
{
    public interface INotesAppService
    {
        NotesAdicionarRequest Adicionar(NotesAdicionarRequest user, string token);
        string Atualizar(NotesAtualizarRequest user, string token);
        string RemoverLogica(Guid id);
        IEnumerable<NotesObterResponse> ObterTodos();
        NotesObterResponse ObterPorId(Guid id);
        IEnumerable<NotesObterResponse> ObterPorUsuario(string token);
        IEnumerable<Notes> ObterPorUsuarioLixeira(string token);
        IEnumerable<Notes> ObterPorUsuarioArquivado(string token);
        string ArquivarLogica(Guid notaId);
    }
}
