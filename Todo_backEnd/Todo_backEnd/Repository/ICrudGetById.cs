using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;

namespace Todo_backEnd.Repository
{
    public interface ICrudGetById
    {
        Response GetTodoById(SqlConnection connection, int id);
    }
}
