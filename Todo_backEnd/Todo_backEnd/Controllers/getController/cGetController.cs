using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Todo_backEnd.Model.ResponseModel;
using Todo_backEnd.Repository.RepositoryImpl;
using Todo_backEnd.Service.serviceInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;


namespace Todo_backEnd.Controllers.getController
{
    [Route("api/[controller]")]
    [ApiController]
    public class cGetController : ControllerBase
    {
        private readonly ICrudGetService _crudGetService;
        private readonly IConfiguration _configuration;

        public cGetController(ICrudGetService crudGetService, IConfiguration configuration)
        {
            _crudGetService = crudGetService;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllTodos")]
        public Response GetAllTodos()
        {
            
                
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
                Response response = new Response();

                 response = _crudGetService.get(connection);
                    return response;


                
           
        }
    }
}
