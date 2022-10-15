using uNotes.Application.Requests.Grupo;
using uNotes.Application.Responses.Grupo;

namespace uNotes.Application.AppService.Interface
{
    public interface IGrupoAppService
    {
        GrupoAdicionarRequest Adicionar(GrupoAdicionarRequest user);
        string Atualizar(GrupoAtualizarRequest user);
        void Remover(Guid id);
        IEnumerable<GrupoObterResponse> ObterGrupos();
        GrupoObterResponse ObterPorId(Guid id);
        string VincularUsuario(VincularUsuarioRequest vincularUsuario);
    }
}
