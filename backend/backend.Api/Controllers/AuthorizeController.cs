using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Core;
using backend.Core.Entities;
using backend.Core.ViewModel.Authrization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using backend.Core.Interfaces;

namespace backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;

        public AuthorizeController(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        public IActionResult Token([FromBody]LoginViewModel viewModel)
        {
            if (!(viewModel.UserName == "admin" && viewModel.Password == "123456"))
                return BadRequest();

            var claim = new Claim[]
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Role, "SysAdmin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claim, DateTime.Now, DateTime.Now.AddDays(1), creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), tokenHeader = "Bearer" });
        }

        [HttpPost]
        public async Task<IActionResult> Regist([FromBody] RegistViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = new User
                {
                    Id = 0,
                    UserName = viewModel.UserName,
                    NickName = viewModel.NickName,
                    Password = viewModel.Password,
                    UserRole = CustomEnum.UserRole.User
                };

                _userRepository.AddUser(user);

                await _unitOfWork.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}