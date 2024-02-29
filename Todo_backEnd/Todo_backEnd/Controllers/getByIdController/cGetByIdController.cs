using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Repository.RepositoryImpl;
using Todo_backEnd.Service.serviceInterface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Todo_backEnd.Controllers.getByIdController
{
    [Route("api/[controller]")]
    [ApiController]
    public class cGetByIdController : ControllerBase
    {
        private readonly ICrudGetByIdService _crudGetBy;
        private readonly IConfiguration _configuration;


        public cGetByIdController(IConfiguration configuration, ICrudGetByIdService crudGetBy)
        {
            _configuration = configuration;
            _crudGetBy = crudGetBy;
        }
        [Authorize]
        [HttpGet]
        [Route("GetTodoById/{id}")]
        public Response GetTodoById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            
            response = _crudGetBy.sGetById(connection, id);

            return response;
        }
    }
}
