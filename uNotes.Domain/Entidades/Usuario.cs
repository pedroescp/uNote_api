namespace uNotes.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public Guid CargoId { get; set; }
        public Guid? Avatar { get; set; }

        //Entidades de navegação
        public virtual Cargo Cargo { get; set; }

        public void Atualizar(Usuario novoUsuario)
        {
            Login = novoUsuario.Login;
            Nome = novoUsuario.Nome;
            Email = novoUsuario.Email;
            Telefone = novoUsuario.Telefone;
            CargoId = novoUsuario.CargoId;
        }
    }
}
