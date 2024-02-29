using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Service.serviceImpl
{
    public class CrudUpdateService : ICrudUpdateService
    {
        private readonly ICrudUpdate _crudUpdate;

        public CrudUpdateService(ICrudUpdate crudUpdate)
        {
            _crudUpdate = crudUpdate;
        }
        Response ICrudUpdateService.sUpdate(SqlConnection connection, Todo todo)
        {
            return _crudUpdate.UpdateTodo(connection, todo);
        }
    }
}
