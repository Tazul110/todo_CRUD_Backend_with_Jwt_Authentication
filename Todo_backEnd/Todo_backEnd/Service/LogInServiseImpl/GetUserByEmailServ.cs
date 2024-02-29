using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.LogInResponseModel;
using Todo_backEnd.Repository.LogInRepositoryInterface;
using Todo_backEnd.Service.LogInServiseInterface;

namespace Todo_backEnd.Service.LogInServiseImpl
{
    public class GetUserByEmailServ : IGetUserByEmailServ
    {
        private readonly IGetUserByEmail _iGetUserByEmail;
        public GetUserByEmailServ(IGetUserByEmail IGetRepo)
        {
            _iGetUserByEmail = IGetRepo;
        }
        public LogInResponse sGetUser(SqlConnection connection, string email)
        {
            return _iGetUserByEmail.GetUserByEmail(connection, email);
        }
    }
}
