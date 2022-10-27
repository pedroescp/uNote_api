using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(uNotesContext context) : base(context)
        {
        }
    }
}
