using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Model.TodoModel;
using Todo_backEnd.Repository;
using Todo_backEnd.Repository.RepositoryImpl;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Controllers.addController
{
    [Route("api/[controller]")]
    [ApiController]
    public class cAddController : ControllerBase
    {
        private readonly ICrudAddService _service;
        private readonly IConfiguration _configuration;

        public cAddController(IConfiguration configuration,ICrudAddService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [Authorize]
        [HttpPost]
        [Route("AddTodo")]
        public Response AddTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            
            response = _service.sAdd(connection, todo);
            return response;
        }
    }
}
