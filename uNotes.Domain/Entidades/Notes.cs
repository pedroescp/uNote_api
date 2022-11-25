namespace uNotes.Domain.Entidades
{
    public class Notes : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }

        public Guid CriadorId { get; set; }

        public bool Lixeira { get; set; }
        public bool Fixado  { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }

        public void Atualizar(Notes novoNotes)
        {
            Titulo = novoNotes.Titulo;
            Texto = novoNotes.Texto;
            UsuarioAtualizacaoId = novoNotes.UsuarioAtualizacaoId;
            
        }
    }
}
