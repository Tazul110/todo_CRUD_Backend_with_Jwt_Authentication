using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Service.serviceInterface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Todo_backEnd.Service.serviceImpl
{
    public class CrudGetService : ICrudGetService
    {
        private readonly ICrudGet _ICrudGet;

        public CrudGetService(ICrudGet IcrudGet)
        {
            _ICrudGet= IcrudGet;
        }
        Response ICrudGetService.get(SqlConnection connection)
        {
            return _ICrudGet.GetAllTodos(connection);
        }

       
    }
}
