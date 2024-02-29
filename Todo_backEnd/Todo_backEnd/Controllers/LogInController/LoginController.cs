using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Repository.LogInRepositoryInterface;

namespace Todo_backEnd.Controllers.LogInController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IGetUserByEmail _user;
        

        public LoginController(IConfiguration configuration, IGetUserByEmail user)
        {
            _config = configuration;
            _user = user;
           
        }

        private Users AuthenticateUser(Users user)
        {
            /*Users _user = null;
            if (user.userName == "admin" && user.userPassword == "12345")
            {
                _user = new Users { userName = "Tazul islam" };
            }
            return _user;*/

            SqlConnection connection = new SqlConnection(_config.GetConnectionString("CrudConnection"));
            LogInResponse rs = _user.GetUserByEmail(connection, user.userEmail);

            if (rs.Users != null && user.userPassword == rs.Users.userPassword)
            {
                return rs.Users;
            }

            return null;
        }


        private string GenerateToken(Users user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login(Users user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if (user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new { token = token, message = "valid credentials" });
            }
            else
            {
                response = BadRequest(new { message = "Try Again... Invalid user or Invalid password" });
            }
            return response;
        }
    }
}
