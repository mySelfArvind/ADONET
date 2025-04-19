using ADONET.DTO;
using ADONET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlAdapterOperationController : ControllerBase
    {
        SqlAdapterOperationService _service;
        public SqlAdapterOperationController()
        {
            _service = new SqlAdapterOperationService();
        }

        [HttpGet]
        [Route("AllAppUsers")]
        public IActionResult GetAllAppUsers()
        {
            return Ok(_service.GetAllAppUsers());
        }

        [HttpGet]
        [Route("AppUsersById{id:int}")]
        public IActionResult GetAppUsersById([FromRoute] int id)
        {
            return Ok(_service.GetAppUsersById(id));
        }

        [HttpGet]
        [Route("AllAppUsersProc")]
        public IActionResult GetAllAppUsersProc()
        {
            return Ok(_service.GetAllAppUsersProc());
        }

        [HttpGet]
        [Route("AllAppUsersByIdProc{id:int}")]
        public IActionResult GetAllAppUsersByIdProc([FromRoute] int id)
        {
            return Ok(_service.GetAllAppUsersByIdProc(id));
        }

        [HttpGet]
        [Route("EmployeesProducts")]
        public IActionResult GetEmployeesProducts()
        {
            return Ok(_service.GetEmployeesProducts());
        }
    }
}
