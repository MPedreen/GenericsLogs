using Microsoft.AspNetCore.Mvc;

namespace GenericsLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        public IActionResult ArmazenarLogs()
            => Ok("Logs armazenados com sucesso.");
    }
}
