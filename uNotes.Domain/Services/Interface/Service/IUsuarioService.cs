using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IUsuarioService : IService<Usuario>
    {
        void AdicionarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        Usuario? ObterUsuarioPorLoginOuEmail(string login);
        string ExisteUsuario(Usuario usuario);
    }
}
