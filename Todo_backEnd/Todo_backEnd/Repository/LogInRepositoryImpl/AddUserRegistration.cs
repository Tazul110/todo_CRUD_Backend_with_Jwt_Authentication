using Dapper;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Repository.LogInRepositoryInterface;

namespace Todo_backEnd.Repository.LogInRepositoryImpl
{
    public class AddUserRegistration : IAddUserRegistration
    {
        public LogInResponse AddUser(SqlConnection connection, Users user)
        {
            LogInResponse lresponse = new LogInResponse();

            int i = connection.Execute("INSERT INTO Users (userName, userEmail, userPassword) VALUES (@userName, @userEmail, @userPassword)", user);

            if (i > 0)
            {

                lresponse.StatusCode = 200;
                lresponse.StatusMessage = "User added.";
                lresponse.Users = user;

            }
            else
            {
                lresponse.StatusCode = 100;
                lresponse.StatusMessage = "No Data inserted";


            }
            return lresponse;
        }
    }
}
