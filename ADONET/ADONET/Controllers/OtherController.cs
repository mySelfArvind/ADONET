using ADONET.DTO;
using ADONET.Repositories;
using ADONET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        OtherService _otherService;
        public OtherController()
        {
            _otherService = new OtherService();
        }

        [HttpGet("GetEmployeesAndAppUsers")]
        public IActionResult GetEmployeesAndAppUsers()
        {
            return Ok(_otherService.GetEmployeesAndAppUsers());
        }
    }
}
