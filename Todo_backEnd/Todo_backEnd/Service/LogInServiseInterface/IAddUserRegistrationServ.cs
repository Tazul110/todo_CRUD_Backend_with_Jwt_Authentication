using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Service.LogInServiseInterface
{
    public interface IAddUserRegistrationServ
    {
        LogInResponse sAdd(SqlConnection connection, Users user);
    }
}
