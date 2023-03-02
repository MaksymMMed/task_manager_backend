using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;
using TodoBackendDAL;
using TodoBackendDAL.Entities;

namespace TodoBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration Configuration;
        public readonly ToDoContext Context;

        public LoginController(IConfiguration configuration, ToDoContext context)
        {
            Configuration = configuration;
            Context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<User> GetUser(string username, string password)
        {
            return await Context.UserTable.Where(u => u.Login == username.Trim() && u.Password == password.Trim()).FirstOrDefaultAsync();
        }

        [HttpPost(Name = "SignUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SignUp()
        {

        }

        [HttpPost(Name = "SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SignIn(string username, string password)
        {
            if (password != null && username != null)
            {
                var userData = await GetUser(username,password);
                var jwt = Configuration.GetSection("Jwt").Get<Jwt>();
                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id",userData.Id.ToString()),
                        new Claim("Login",userData.Login.ToString()),
                        new Claim("Password",userData.Password.ToString()),
                        new Claim("Email",userData.Email.ToString())
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims,
                        expires: DateTime.Now.AddMinutes(30),signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}
