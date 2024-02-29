using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;

namespace Todo_backEnd.Service.serviceInterface
{
    public interface ICrudGetByIdService
    {
        Response sGetById(SqlConnection connection, int id);
    }
}
