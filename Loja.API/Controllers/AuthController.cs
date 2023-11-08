using Loja.Services.Services.LoginServices;
using Loja.Services.Services.PersonServices.Models;
using Loja.Services.Services.TokenServices.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Loja.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {

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


        [HttpPost]
        [Route("refresh")]
        
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null) return BadRequest("Invalid client request");
            var token = _loginService.ValidateCredentials(tokenVo);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginService.RevokeToken(username);
            if (!result) return BadRequest("Invalid client request");
              
            return NoContent();
        }

    }

}

