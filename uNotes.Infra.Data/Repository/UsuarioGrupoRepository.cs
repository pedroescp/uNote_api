using Microsoft.EntityFrameworkCore;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class UsuarioGrupoRepository : Repository<UsuarioGrupo>, IUsuarioGrupoRepository
    {
        public UsuarioGrupoRepository(uNotesContext context) : base(context)
        {
        }

    
    }
}
