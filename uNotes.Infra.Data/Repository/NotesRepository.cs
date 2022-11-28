using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class NotesRepository : Repository<Notes>, INotesRepository
    {
        public NotesRepository(uNotesContext context) : base(context)
        {
        }

        public IEnumerable<Notes> ObterPorUsuario(Guid usuarioId)
        {
            return DbSet.Where(x => x.CriadorId == usuarioId);
        }
    }
}
