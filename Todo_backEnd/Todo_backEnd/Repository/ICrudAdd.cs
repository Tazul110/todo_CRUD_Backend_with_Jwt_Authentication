using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Repository
{
    public interface ICrudAdd
    {
        Response AddTodo(SqlConnection connection, Todo todo);
    }
}
