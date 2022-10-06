using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Usuario;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService, INotificador notificador, ILogger<UsuarioController> logger) : base(notificador, logger)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Adicionar(UsuarioAdicionarRequest usuario) => CustomPostResponse(_usuarioAppService.Adicionar(usuario));

        [HttpPut]
        public IActionResult Atualizar(UsuarioAtualizarRequest usuario) => CustomPutResponse(_usuarioAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_usuarioAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_usuarioAppService.ObterTodos());
    }
}