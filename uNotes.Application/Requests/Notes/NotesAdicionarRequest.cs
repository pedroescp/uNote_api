namespace uNotes.Application.Requests.Notes
{
    public class NotesAdicionarRequest
    {
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        public Guid CriadorId { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }
        public string Token { get; set; }
    }
}
