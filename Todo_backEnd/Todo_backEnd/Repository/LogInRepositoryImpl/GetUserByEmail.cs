using Dapper;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogIn_UsersModel;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Repository.LogInRepositoryInterface;

namespace Todo_backEnd.Repository.LogInRepositoryImpl
{
    public class GetUserByEmail : IGetUserByEmail
    {
        LogInResponse IGetUserByEmail.GetUserByEmail(SqlConnection connection, string email)
        {
            LogInResponse lresponse = new LogInResponse();

            var user = connection.QueryFirstOrDefault<Users>("SELECT * FROM Users WHERE userEmail = @userEmail", new { userEmail = email });

            if (user != null)
            {
                lresponse.StatusCode = 200;
                lresponse.StatusMessage = "Data found";
                lresponse.Users = user;
            }
            else
            {
                lresponse.StatusCode = 100;
                lresponse.StatusMessage = "No Data found";
                lresponse.Users = null;
            }

            return lresponse;
        }
    }
}
