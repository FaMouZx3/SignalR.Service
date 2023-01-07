using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Service.Hubs;

namespace SignalR.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;

        public HomeController(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("PushMessage")]
        public async Task<IActionResult> PushMessage(string Message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", Message);
            return Ok("Done");
        }
    }
}
