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

        public int TotalEmployees()
        {
            return EmployeeRepository.TotalEmployees();
        }

        public string AddNewEmployee(EmployeeDTO employee)
        {
            return EmployeeRepository.AddNewEmployee(employee);
        }
        public string UpdateEmployee(int id,EmployeeDTO employee)
        {
            return EmployeeRepository.UpdateEmployee(id,employee);
        }

        public string DeleteEmployee(int id)
        {
            return EmployeeRepository.DeleteEmployee(id);
        }
    }
}
