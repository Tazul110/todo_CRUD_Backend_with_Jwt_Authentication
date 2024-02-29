using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Service.serviceImpl
{
    public class CrudAddService : ICrudAddService
    {
        private readonly ICrudAdd _crudAdd;
        public CrudAddService(ICrudAdd crudAdd)
        {
            _crudAdd = crudAdd;
        }
        Response ICrudAddService.sAdd(SqlConnection connection, Todo todo)
        {
            return _crudAdd.AddTodo(connection, todo);
        }
    }
}
