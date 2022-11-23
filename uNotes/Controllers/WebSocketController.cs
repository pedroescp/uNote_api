using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.WebSocketService;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("websocket")]
    [Authorize]
    public class WebSocketController : BaseController
    {
        private readonly IWebSocketCalls _webSocketCalls;
        public WebSocketController(IWebSocketCalls webSocketCalls, INotificador notificador, ILogger<WebSocketController> logger) : base(notificador, logger)
        {
            _webSocketCalls = webSocketCalls;
        }

        [AllowAnonymous]
        [HttpGet("/ws")]
        public async Task Obter()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await _webSocketCalls.Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
