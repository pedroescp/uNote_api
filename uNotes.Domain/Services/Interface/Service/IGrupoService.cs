using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IGrupoService : IService<Grupo>
    {
        void AtualizarGrupo(Grupo grupo);
        IEnumerable<Grupo> ObterGrupos();
    }

}
