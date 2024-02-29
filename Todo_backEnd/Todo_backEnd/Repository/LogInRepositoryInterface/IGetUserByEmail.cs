using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogInResponseModel;

namespace Todo_backEnd.Repository.LogInRepositoryInterface
{
    public interface IGetUserByEmail
    {
        LogInResponse GetUserByEmail(SqlConnection connection, string email);
    }
}
