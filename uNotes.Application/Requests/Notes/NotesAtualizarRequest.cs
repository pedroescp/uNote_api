namespace uNotes.Application.Requests.Notes
{
    public class NotesAtualizarRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        public Guid CriadorId { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid DocumentoId { get; set; }
    }
}

