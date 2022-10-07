using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPP.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CustomerAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        CustomerDBContext db;
        private IConfiguration _config;
        public LoginController(IConfiguration config, CustomerDBContext _db)
        {
            _config = config;
            db = _db;
        }
        [HttpPost]
        [Route("login-user")]
        public IActionResult Login(TblLogin login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login,false);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private TblLogin AuthenticateUser(TblLogin login,bool IsRegister)
        {
            if (IsRegister)
            {
                db.TblLogins.Add(login);
                return login;
            }
            else
            {
                if (db.TblLogins.Any(x => x.UserName == login.UserName && x.Password == login.Password))
                {
                    return db.TblLogins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
       
        }

        private string GenerateToken(TblLogin login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                { 
                    new Claim(ClaimTypes.Name, login.UserName) 
                }),
                Expires=DateTime.Now.AddMinutes(120),
                SigningCredentials= credentials
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = TokenHandler.CreateToken(token);
            return TokenHandler.WriteToken(tokenGenerated).ToString();
        }

        [HttpPost]
        [Route("register-user")]
        public IActionResult Register(TblLogin login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login,true);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpGet]
        [Route("get-data")]
        public IEnumerable<TblDummyDatum> GetData(int id)
        {
            return db.TblDummyData.Where(x => x.LoginId == id);
        }
    }
}
