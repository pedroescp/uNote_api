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
        public IActionResult Adicionar([FromBody] NotesAdicionarRequest notes) => CustomPostResponse(_notesAppService.Adicionar(notes));

        [HttpPut]
        public IActionResult Atualizar([FromBody] NotesAtualizarRequest notes) => CustomPutResponse(_notesAppService.Atualizar(notes));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_notesAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_notesAppService.ObterTodos());
    }
}
