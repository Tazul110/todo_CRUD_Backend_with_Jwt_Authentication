using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Model.ResponseModel;
using Dapper;

namespace Todo_backEnd.Repository;

public class CrudAdd : ICrudAdd
{
    public Response AddTodo(SqlConnection connection, Todo todo)
    {
        Response response = new Response();

        int i = connection.Execute("INSERT INTO todo (Descrip, IsActive, Title, DueOn, Priority, CreatedOn) VALUES (@Descrip, @IsActive, @Title, @DueOn, @Priority, GETDATE())", todo);
        
        /*SqlCommand cmd = new SqlCommand("INSERT INTO todo (Descrip, IsActive, Title, DueOn, Priority, CreatedOn) VALUES (@Descrip, @IsActive, @Title, @DueOn, @Priority, GETDATE())", connection);

        cmd.Parameters.AddWithValue("@Descrip", todo.Descrip);
        cmd.Parameters.AddWithValue("@IsActive", todo.IsActive);
        cmd.Parameters.AddWithValue("@Title", todo.Title);
        cmd.Parameters.AddWithValue("@DueOn", todo.DueOn);
        cmd.Parameters.AddWithValue("@Priority", todo.Priority);

        connection.Open();
        int i = cmd.ExecuteNonQuery();
        connection.Close();*/

        if (i > 0)
        {

            response.StatusCode = 200;
            response.StatusMessage = "Todo added.";
            response.Todo = todo;

        }
        else
        {
            response.StatusCode = 100;
            response.StatusMessage = "No Data inserted";


        }
        return response;

    }

   
}
