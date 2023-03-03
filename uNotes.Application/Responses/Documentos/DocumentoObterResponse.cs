namespace uNotes.Application.Responses.Documentos
{
    public class DocumentoObterResponse
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}
