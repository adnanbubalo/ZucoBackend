using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ZucoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;

        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Admin>> Register(AdminDto adminDto)
        {
            var admin = await loginService.Register(adminDto);
            return Ok(admin);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Admin>> Login([FromBody]AdminDto adminDto)
        {
            var admin = await loginService.GetAdmin(adminDto.Username);
            if (admin == null)
                return BadRequest("Incorrect username or password");
            if(!loginService.VerifyPasswordHash(adminDto.Password, admin.PasswordHash, admin.PasswordSalt))
                return BadRequest("Incorrect username or password");
            var token = loginService.CreateToken(admin);
            if (token == null)
                return Unauthorized();
            return Ok(new { token });
        }
    }
}
