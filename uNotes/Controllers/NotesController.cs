using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Notes;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("notes")]
    [Authorize]
    public class NotesController : BaseController
    {
        private readonly INotesAppService _notesAppService;
        public NotesController(INotesAppService notesAppService, INotificador notificador, ILogger<NotesController> logger) : base(notificador, logger)
        {
            _notesAppService = notesAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] NotesAdicionarRequest notes) => CustomPostResponse(_notesAppService.Adicionar(notes, notes.Token));

        [HttpPut]
        public IActionResult Atualizar([FromBody] NotesAtualizarRequest notes) => CustomPutResponse(_notesAppService.Atualizar(notes));

        [HttpDelete]
        public IActionResult Remover(Guid notaId) => CustomDeleteResponse(_notesAppService.RemoverLogica(notaId));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_notesAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_notesAppService.ObterTodos());

        [HttpGet("obter-por-usuario")]
        public IActionResult ObterPorUsuario(Guid usuarioId) => CustomResponse(_notesAppService.ObterPorUsuario(usuarioId));

        [HttpGet("obter-por-usuario-arquivado")]
        public IActionResult ObterPorUsuarioArquivado(Guid usuarioId) => CustomResponse(_notesAppService.ObterPorUsuarioArquivado(usuarioId));

        [HttpGet("obter-por-usuario-lixeira")]
        public IActionResult ObterPorUsuarioLixeira(Guid usuarioId) => CustomResponse(_notesAppService.ObterPorUsuarioLixeira(usuarioId));
    }
}
