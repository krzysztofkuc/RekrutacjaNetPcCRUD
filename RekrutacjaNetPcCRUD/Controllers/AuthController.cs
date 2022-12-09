using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RekrutacjaNetPcCRUD.Model.Entities;
using RekrutacjaNetPcCRUD.Model.ViewModel;
using RekrutacjaNetPcCRUD.Repositories.ContactsDbContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RekrutacjaNetPcCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly RekrutacjaNetPcCrudContext _contactsCtx;

        public AuthController(IConfiguration config, RekrutacjaNetPcCrudContext contactsCtx)
        {
            _config = config;
            _contactsCtx = contactsCtx;
        }

        [AllowAnonymous]
        [HttpPost]
        public  IActionResult Login([FromBody] UserVm user)
        {
            var userEntity = Authenticate(user);

            if(user != null)
            {
                var token = GenerateToken(userEntity);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials  = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], 
                                            _config["Jwt:Audience"], 
                                            claims, 
                                            expires: DateTime.Now.AddMinutes(15),
                                            signingCredentials: credentials );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Users Authenticate(UserVm user)
        {
            var currentUser = _contactsCtx.Users.FirstOrDefault(u => u.Email.ToLower() == user.Email &&
                                                                u.Password == user.Password);

            if(currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
