using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Repository.RepositoryImpl;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Controllers.updateController
{
    [Route("api/[controller]")]
    [ApiController]
    public class cUpdateController : ControllerBase
    {
        private readonly ICrudUpdateService _service;
        private readonly IConfiguration _configuration;


        public cUpdateController(IConfiguration configuration, ICrudUpdateService service)
        {
            _configuration = configuration;
            _service=service;
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateTodo")]
        public Response UpdateTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            
            response = _service.sUpdate(connection, todo);
            return response;
        }
    }
}
