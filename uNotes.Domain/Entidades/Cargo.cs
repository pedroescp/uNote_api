namespace uNotes.Domain.Entidades
{
    public class Cargo : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public void Atualizar(Cargo cargo)
        {
            Nome = cargo.Nome;
            Descricao = cargo.Descricao;
        }
    }
}
