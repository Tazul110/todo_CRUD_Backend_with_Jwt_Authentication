using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;

namespace Todo_backEnd.Repository.RepositoryImpl
{
    public class CrudGet: ICrudGet
    {
        public Response GetAllTodos(SqlConnection connection)
        {


            Response response = new Response();
            var lstTodos = connection.Query<Todo>("SELECT * FROM todo ORDER BY DueOn").ToList();

            if (lstTodos.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listTodo = lstTodos;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data found";
                response.listTodo = null;
            }

            return response;







            /*Response response = new Response();

            var lstTodos = connection.Query<Todo>("SELECT * FROM todo ORDER BY DueOn").ToList();
            SqlDataAdapter da = new SqlDataAdapter("select * from todo", connection);
            DataTable dt = new DataTable();
            List<Todo> lstTodos = new List<Todo>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Todo todo = new Todo();

                    todo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);

                    todo.Title = Convert.ToString(dt.Rows[i]["Title"]);

                    todo.DueOn = Convert.ToDateTime(dt.Rows[i]["DueOn"]);
                    todo.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);

                    todo.Descrip = Convert.ToString(dt.Rows[i]["Descrip"]);

                    todo.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);

                    todo.Priority = Convert.ToString(dt.Rows[i]["Priority"]);

                    lstTodos.Add(todo);
                }



                lstTodos = lstTodos.OrderBy(t => t.DueOn).ToList();
            }
            if (lstTodos.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listTodo = lstTodos;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data found";
                response.listTodo = null;
            }
            return response;*/


        }
    }
}

