using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Service.serviceImpl
{
    public class CrudGetByIdService : ICrudGetByIdService
    {
        private readonly ICrudGetById _ICrudGetById;
        public CrudGetByIdService(ICrudGetById iCrudGetById)
        {
             _ICrudGetById= iCrudGetById;
        }

        Response ICrudGetByIdService.sGetById(SqlConnection connection, int id)
        {
            return _ICrudGetById.GetTodoById(connection, id);
        }
    }
}
