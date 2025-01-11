using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Test.Millon.API.Models.Utility;
using Test.Millon.API.Services;

namespace Test.Millon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class AuthenticationController : Controller
    {        
        private readonly IAuthenticationMillon _authenticationMillon;

        public AuthenticationController(IAuthenticationMillon authenticationMillon)
        {           
            _authenticationMillon = authenticationMillon;
        }


        [HttpPost(Name = MillonConstans.Login)]
        public IActionResult Login(string user, string password)
        {
            string token = _authenticationMillon.LoginAsync(user, password);
            if(token.IsNullOrEmpty())
                return Unauthorized();

            return Ok(new { Token = token });            
        }
    }
}
