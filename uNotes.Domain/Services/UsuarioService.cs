using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Criptografia;
using uNotes.Infra.CrossCutting.Enums;

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

        public void AdicionarUsuario(Usuario usuario)
        {
            usuario.Senha = Criptografia.Encrypt(usuario.Senha, TipoCriptografia.SenhaLogin);
            base.Adicionar(usuario);
        }

        public Usuario? ObterUsuarioPorLoginOuEmail(string login)
        {
            return _usuarioRepository.ObterPorEmailOuLogin(login);
        }

        public string ExisteUsuario(Usuario usuario)
        {
            var usuarios = _usuarioRepository.ObterTodos();
            if (usuarios.Any(x => x.Email == usuario.Email))
                return "Email já existente";
            if (usuarios.Any(x => x.Login == usuario.Login))
                return "Login já existente";
            return "";
        }
    }
}
