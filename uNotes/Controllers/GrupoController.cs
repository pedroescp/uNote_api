using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Grupo;
using uNotes.Application.Requests.Usuario;
using uNotes.Domain.Entidades;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("grupo")]
    public class GrupoController : BaseController
    {
        private readonly IGrupoAppService _grupoAppService;

        public GrupoController(IGrupoAppService grupoAppService, INotificador notificador, ILogger<GrupoController> logger) : base(notificador, logger)
        {
            _grupoAppService = grupoAppService;
        }

        [HttpPost]
        public IActionResult Adicionar(GrupoAdicionarRequest usuario) => CustomPostResponse(_grupoAppService.Adicionar(usuario));

        [HttpPut]
        public IActionResult Atualizar(GrupoAtualizarRequest usuario) => CustomPutResponse(_grupoAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_grupoAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_grupoAppService.ObterGrupos());

        [HttpPost("vincular-usuario")]
        public IActionResult VincularUsuario(VincularUsuarioRequest vincularUsuario) => CustomPostResponse(_grupoAppService.VincularUsuario(vincularUsuario));
    }
}
