using Behelit.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Behelit.Controllers
{
    [ApiController]
    [Route("/api/message")]
    public class MessageController : Controller
    {
        private readonly IHubContext<MessageHub> _messageHub;

        public MessageController(IHubContext<MessageHub> messageHub)
        {
            _messageHub = messageHub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessagePost messagePost)
        {
            await _messageHub.Clients.All.SendAsync("sentToReact", $"The message {messagePost.Message} has been received.");

            return Ok();
        }
    }

    public class MessagePost
    {
        public virtual string Message { get; set; }
    }
}
