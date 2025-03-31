using ADONET.DTO;
using ADONET.Repositories;

namespace ADONET.Services
{
    public class OtherService
    {
        OtherRepository _otherRepository;
        public OtherService()
        {
            _otherRepository = new OtherRepository();
        }

        public EmployeeAndAppUserDTO GetEmployeesAndAppUsers()
        {
            return _otherRepository.GetEmployeesAndAppUsers();
        }
    }
}
