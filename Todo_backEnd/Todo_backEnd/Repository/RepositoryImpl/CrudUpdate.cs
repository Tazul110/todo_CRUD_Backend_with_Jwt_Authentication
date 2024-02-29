using Dapper;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Repository.RepositoryImpl
{
    public class CrudUpdate: ICrudUpdate
    {
        public Response UpdateTodo(SqlConnection connection, Todo todo)
        {
            Response response = new Response();


            int rowsAffected = connection.Execute("UPDATE todo SET Descrip=@Descrip, Title=@Title, Priority=@Priority, IsActive=@IsActive, DueOn=@DueOn WHERE Id=@Id", todo);

            if (rowsAffected > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo updated.";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No todo updated";
            }

            return response;



            /*SqlCommand cmd = new SqlCommand("UPDATE todo SET Descrip=@Descrip, Title=@Title, Priority=@Priority, IsActive=@IsActive, DueOn=@DueOn WHERE Id=@Id", connection);

            cmd.Parameters.AddWithValue("@Descrip", todo.Descrip);
            cmd.Parameters.AddWithValue("@Title", todo.Title);
            cmd.Parameters.AddWithValue("@Priority", todo.Priority);
            cmd.Parameters.AddWithValue("@IsActive", todo.IsActive);
            cmd.Parameters.AddWithValue("@DueOn", todo.DueOn);
            cmd.Parameters.AddWithValue("@Id", todo.Id);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo updated.";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No todo updated";
            }
            return response;*/
        }
    }
}
