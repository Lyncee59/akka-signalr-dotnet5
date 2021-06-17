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
        [HttpGet]
        public async Task<IActionResult> Create(MessagePost messagePost)
        {
            return Ok($"Message received ! " + messagePost.Message);
        }
    }

    public class MessagePost
    {
        public virtual string Message { get; set; }
    }
}
