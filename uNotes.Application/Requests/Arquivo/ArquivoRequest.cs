using Microsoft.AspNetCore.Http;

namespace uNotes.Application.Requests.Arquivo
{
    public class ArquivoRequest
    {
        public IFormFile Arquivo { get; set; }
        public Guid DocumentoId { get; set; }
    }
}
