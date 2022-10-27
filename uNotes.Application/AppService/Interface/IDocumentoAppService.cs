using uNotes.Application.Requests.Documento;
using uNotes.Application.Responses.Documento;

namespace uNotes.Application.AppService.Interface
{
    public interface IDocumentoAppService
    {
        DocumentoAdicionarRequest Adicionar(DocumentoAdicionarRequest user);
        string Atualizar(DocumentoAtualizarRequest documento);
        void Remover(Guid id);
        IEnumerable<DocumentoObterResponse> ObterTodos();
        DocumentoObterResponse ObterPorId(Guid id);
    }
}
