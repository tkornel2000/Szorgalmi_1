using Academy_2023.Data;
using Academy_2023.Dto;
using Academy_2023.Helpers;
using Academy_2023.Repositories;
using Academy_2023.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(
            IAccountService accountService,
            ITokenService tokenService,
            IUserService userService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> LoginAsync([FromBody] LoginDto loginDto)
        {
            var user = await _accountService.LoginAsync(loginDto);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.CreateToken(user);

            return Ok(token);
        }

        
    }
}