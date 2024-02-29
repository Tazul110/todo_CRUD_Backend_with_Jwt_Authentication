using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;

using Todo_backEnd.Repository.LogInRepositoryInterface;
using Todo_backEnd.Service.LogInServiseInterface;

namespace Todo_backEnd.Controllers.LogInController
{
    [Route("api/[controller]")]
    [ApiController]
    public class userResistrationController : ControllerBase
    {
        private readonly IConfiguration _Config;
        private readonly IAddUserRegistrationServ _user;

        public userResistrationController(IConfiguration Config, IAddUserRegistrationServ user)
        {
            _Config = Config;
            _user = user;
        }

        
        [HttpPost]
        [Route("userRegistration")]
        public LogInResponse userRegistration(Users user)
        {
            SqlConnection connection = new SqlConnection(_Config.GetConnectionString("CrudConnection"));
            LogInResponse response = new LogInResponse();

            response = _user.sAdd(connection,user);
            return response;
        }
    }
}
