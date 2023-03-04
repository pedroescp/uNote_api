﻿using uNotes.Application.Requests.NotaDocumentos;
using uNotes.Application.Responses.Notes;

namespace uNotaDocumento.Application.AppService.Interface
{
    public interface INotaDocumentoAppService
    {
        NotaDocumentoAdicionarRequest Adicionar(NotaDocumentoAdicionarRequest user, string token);
        string Atualizar(NotaDocumentoAtualizarRequest user, string token);
        void Remover(Guid id);
        NotaDocumentoObterResponse ObterPorId(Guid id);
        IEnumerable<NotaDocumentoObterResponse> ObterTodos();

    }
}
