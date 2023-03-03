using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class UsuarioGrupoService : Service<UsuarioGrupo>, IUsuarioGrupoService
    {
        public UsuarioGrupoService(IUsuarioGrupoRepository repository) : base(repository)
        {
         
        }
    }
}
