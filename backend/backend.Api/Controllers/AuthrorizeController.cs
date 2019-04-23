using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using backend.Api.Data;
using backend.Api.Models;
using backend.Api.ViewModels;
using backend.Core.Customers;
using backend.Core.Entities;
using backend.Core.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace backend.Api.Controllers
{
    [Route("authorize")]
    public class AuthorizeController : Controller
    {
        private readonly MyContext _db;
        private readonly JwtSettings _jwtSettings;

        public AuthorizeController(MyContext db, IOptions<JwtSettings> jwtSettings)
        {
            _db = db;
            _jwtSettings = jwtSettings.Value;
        }

        public class ReturnToken
        {
            [JsonProperty("tokenHeader")]
            public string TokenHeader { get; set; }
            [JsonProperty("token")]
            public string Token { get; set; }
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(ReturnJson.ServerError("数据格式错误"));

            try
            {
                var user = _db.Users.SingleOrDefault(c => c.UserName == model.UserName);

                if (user.Password != Crypto.DesEncrypt(model.Password))
                    return Json(ReturnJson.ServerError("用户名密码错误"));

                var userRole = Enum.GetName(typeof(CustomerEnum.UserRole), user.UserRole);

                var returnToken = getToken(model.UserName, userRole);

                return Json(ReturnJson.Success(returnToken));
            }
            catch (Exception ex)
            {
                return Json(ReturnJson.ServerError(ex.ToString()));
            }
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(ReturnJson.ServerError("数据格式错误"));

            try
            {
                var user = new User
                {
                    UserName = model.UserName,
                    NickName = model.NickName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Password = Crypto.DesEncrypt(model.Password),
                    UserRole = CustomerEnum.UserRole.Admin
                };

                _db.Users.Add(user);

                _db.SaveChanges();

                var userRole = Enum.GetName(typeof(CustomerEnum.UserRole), user.UserRole);

                var returnToken = getToken(user.UserName, userRole);

                return Json(ReturnJson.Success(returnToken));
            }
            catch (Exception ex)
            {
                return Json(ReturnJson.ServerError(ex.ToString()));
            }
        }


        private ReturnToken getToken(string userName, string userRole)
        {
            var claim = new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, userRole),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claim, DateTime.Now,
                DateTime.Now.AddDays(30), creds);

            return new ReturnToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                TokenHeader = "Bearer"
            };
        }
    }
}