using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;

namespace Todo_backEnd.Service.serviceInterface
{
    public interface ICrudGetService
    {
        Response get(SqlConnection connection);
    }
}
