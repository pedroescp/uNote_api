using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class GrupoService : Service<Grupo>, IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(IGrupoRepository repository) : base(repository)
        {
            _grupoRepository = repository;
        }

        public void AtualizarGrupo(Grupo grupo)
        {
            var antigoGrupo = _grupoRepository.ObterPorId(grupo.Id);
            antigoGrupo.Atualizar(grupo);
            return;
        }
        public IEnumerable<Grupo> ObterGrupos()
        {
            return _grupoRepository.ObterGrupos();
        }
    }
}
