using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Service.serviceInterface
{
    public interface ICrudUpdateService
    {
        Response sUpdate(SqlConnection connection, Todo todo);
    }
}
