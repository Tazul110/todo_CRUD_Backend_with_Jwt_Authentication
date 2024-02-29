using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Service.serviceImpl
{
    public class CrudDeleteService : ICrudDeleteService
    {
        private readonly ICrudDelete _crudDelete;

        public CrudDeleteService(ICrudDelete crudDelete)
        {
            _crudDelete=crudDelete;
        }

        Response ICrudDeleteService.sDelete(SqlConnection connection, int id)
        {
            return _crudDelete.DeleteTodo(connection, id);
        }
    }
}
