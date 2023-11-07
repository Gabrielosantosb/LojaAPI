using Loja.Services.Services.LoginServices;
using Loja.Services.Services.PersonServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Loja.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private ILoginService _loginService;

        public AuthController(ILogger<AuthController> logger, ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] User user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = _loginService.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}
