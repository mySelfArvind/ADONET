using ADONET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Services.EmployeeService EmployeeService = new Services.EmployeeService();

        [HttpGet("AllEmployees")]
        public IActionResult GetAllEmployees()
        {
            List<EmployeeDTO> employees = EmployeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("TotalEmployees")]
        public int TotalEmployees()
        {
            return EmployeeService.TotalEmployees();
        }

        [HttpPost("AddNewEmployee")]
        public string AddNewEmployee([FromBody] EmployeeDTO employee)
        {
            return EmployeeService.AddNewEmployee(employee);
        }

    }
}
