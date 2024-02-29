using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Repository.RepositoryImpl
{
    public class CrudGetById: ICrudGetById
    {
        public Response GetTodoById(SqlConnection connection, int id)
        {
            Response response = new Response();

            var todo = connection.QueryFirstOrDefault<Todo>("SELECT * FROM todo WHERE Id = @Id", new { Id = id });

            if (todo != null)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data found";
                response.Todo = null;
            }

            return response;






            /*SqlDataAdapter da = new SqlDataAdapter("select * from todo WHERE ID = '" + id + "' ", connection);
            DataTable dt = new DataTable();
            Todo Todos = new Todo();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Todo todo = new Todo();

                todo.Id = Convert.ToInt32(dt.Rows[0]["Id"]);

                todo.Title = Convert.ToString(dt.Rows[0]["Title"]);

                todo.DueOn = Convert.ToDateTime(dt.Rows[0]["DueOn"]);
                todo.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);

                todo.Descrip = Convert.ToString(dt.Rows[0]["Descrip"]);

                todo.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                todo.Priority = Convert.ToString(dt.Rows[0]["Priority"]);


                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data found";
                response.Todo = null;

            }
            return response;*/

        }
    }
}
