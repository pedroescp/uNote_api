using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Arquivo;
using uNotes.Application.Responses.Anexo;
using uNotes.Infra.CrossCutting.AWS.Interfaces;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("anexo")]
    [Authorize]
    public class AnexoController : BaseController
    {
        private readonly IAnexoAppService _anexoAppService;
        public AnexoController(IAnexoAppService anexoAppService, INotificador notificador, ILogger<AnexoController> logger) : base(notificador, logger)
        {
            _anexoAppService = anexoAppService;
        }

        [HttpGet("obter-anexos-documento")]
        public IActionResult ObterArquivosPorDocumento([FromQuery] Guid arquivoId) => CustomPutResponse(_anexoAppService.ObterArquivosPorDocumento(arquivoId));

        [HttpPost]
        public IActionResult SalvarArquivo([FromForm] ArquivoRequest arquivo) => CustomPostResponse(_anexoAppService.SalvarArquivo(arquivo.Arquivo, arquivo.DocumentoId));

    }
}
