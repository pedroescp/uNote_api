using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            _usuarioRepository = repository;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            var antigoUsuario = _usuarioRepository.ObterPorId(usuario.Id);
            antigoUsuario.Atualizar(usuario);
            return;
        }
    }
}
