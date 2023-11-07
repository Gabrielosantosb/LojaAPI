﻿using Loja.Services.Services.LoginServices;
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
    }
}
