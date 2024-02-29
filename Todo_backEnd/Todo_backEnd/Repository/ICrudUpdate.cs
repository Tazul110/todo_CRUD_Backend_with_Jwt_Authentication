using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Repository
{
    public interface ICrudUpdate
    {
        Response UpdateTodo(SqlConnection connection, Todo todo);
    }
}
