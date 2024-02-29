using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Repository.RepositoryImpl;
using Todo_backEnd.Service.serviceInterface;

namespace Todo_backEnd.Controllers.deleteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class cDeleteController : ControllerBase
    {
        private readonly ICrudDeleteService _service;
        private readonly IConfiguration _configuration;


        public cDeleteController(IConfiguration configuration, ICrudDeleteService service)
        {
            _configuration = configuration;
             _service= service;
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteTodo/{id}")]

        public Response DeleteTodo(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            
            response = _service.sDelete(connection, id);

            return response;
        }
    }
}
