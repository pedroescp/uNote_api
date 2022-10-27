using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IDocumentoService : IService<Documento>
    {
        void AtualizarDocumento(Documento documento);
    }
}
