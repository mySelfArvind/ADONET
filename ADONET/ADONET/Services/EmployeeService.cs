using ADONET.DTO;
using Microsoft.Data.SqlClient;

namespace ADONET.Services
{
    public class EmployeeService
    {
        Repositories.EmployeeRepository EmployeeRepository = new Repositories.EmployeeRepository();
        public List<EmployeeDTO> GetAllEmployees()
        {
            return EmployeeRepository.GetAllEmployees();
        }
    }
}
