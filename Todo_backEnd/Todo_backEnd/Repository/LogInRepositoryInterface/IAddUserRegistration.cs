using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Repository.LogInRepositoryInterface
{
    public interface IAddUserRegistration
    {
        LogInResponse AddUser(SqlConnection connection, Users user);
    }
}
