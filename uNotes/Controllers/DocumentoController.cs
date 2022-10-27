using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Documento;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("documentos")]
    [Authorize]
    public class DocumentoController : BaseController
    {
        private readonly IDocumentoAppService _documentosAppService;
        public DocumentoController(IDocumentoAppService documentosAppService, INotificador notificador, ILogger<DocumentoController> logger) : base(notificador, logger)
        {
            _documentosAppService = documentosAppService;
        }

        [HttpPost]
        public IActionResult Adicionar(DocumentoAdicionarRequest notes) => CustomPostResponse(_documentosAppService.Adicionar(notes));

        [HttpPut]
        public IActionResult Atualizar(DocumentoAtualizarRequest notes) => CustomPutResponse(_documentosAppService.Atualizar(notes));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_documentosAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_documentosAppService.ObterTodos());
    }
}
