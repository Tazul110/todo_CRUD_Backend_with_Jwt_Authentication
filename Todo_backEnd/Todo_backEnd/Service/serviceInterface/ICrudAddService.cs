using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Service.serviceInterface
{
    public interface ICrudAddService
    {
        Response sAdd(SqlConnection connection, Todo todo);
    }
}
