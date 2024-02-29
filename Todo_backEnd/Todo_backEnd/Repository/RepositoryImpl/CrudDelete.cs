using Dapper;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;

namespace Todo_backEnd.Repository.RepositoryImpl
{
    public class CrudDelete: ICrudDelete
    {
        public Response DeleteTodo(SqlConnection connection, int id)
        {
            Response response = new Response();
            int i= connection.Execute("DELETE FROM todo WHERE Id = @Id", new { Id = id });

            /* SqlCommand cmd = new SqlCommand("Delete from todo WHERE Id = '" + id + "' ", connection);
             connection.Open();
             int i = cmd.ExecuteNonQuery();
             connection.Close();*/

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Todo deletion failed";
            }
            return response;
        }
    }
}
