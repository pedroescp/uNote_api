using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Usuario;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api
{
    [ApiController]
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Autenticar(string emailLogin, string senha) => CustomResponse(_usuarioAppService.Autenticar(emailLogin, senha));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_usuarioAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_usuarioAppService.ObterTodos());
    }
}