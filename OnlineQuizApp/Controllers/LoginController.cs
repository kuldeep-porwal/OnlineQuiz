using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserBiz;
using UserBiz.Model;

namespace OnlineQuizApp.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager loginManager;

        public LoginController(ILoginManager loginManager)
        {
            this.loginManager = loginManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            return Ok(await loginManager.Login(loginRequest));
        }
    }
}