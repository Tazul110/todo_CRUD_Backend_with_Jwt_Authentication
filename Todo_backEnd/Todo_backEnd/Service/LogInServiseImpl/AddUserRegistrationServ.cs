using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Repository.LogInRepositoryInterface;
using Todo_backEnd.Service.LogInServiseInterface;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Service.LogInServiseImpl
{
    public class AddUserRegistrationServ: IAddUserRegistrationServ
    {
        private readonly IAddUserRegistration _crudAdd;
        public AddUserRegistrationServ(IAddUserRegistration crudAdd)
        {
            _crudAdd = crudAdd;
        }

        public LogInResponse sAdd(SqlConnection connection, Users user)
        {
            return _crudAdd.AddUser(connection, user);
        }
        
    }
}
