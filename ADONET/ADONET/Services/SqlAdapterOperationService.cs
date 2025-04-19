using ADONET.DTO;
using ADONET.Repositories;

namespace ADONET.Services
{
    public class SqlAdapterOperationService
    {
        SqlAdapterOperationRepository _repository;
        public SqlAdapterOperationService()
        {
            _repository = new SqlAdapterOperationRepository();
        }

        public List<AppUserDTO>? GetAllAppUsers()
        {
            return _repository.GetAllAppUsers();
        }

        public AppUserDTO? GetAppUsersById(int id)
        {
            return _repository.GetAppUsersById(id);
        }

        public List<AppUserDTO>? GetAllAppUsersProc()
        {
            return _repository.GetAllAppUsersProc();
        }

        public List<AppUserDTO>? GetAllAppUsersByIdProc(int id)
        {
            return _repository.GetAllAppUsersByIdProc(id);
        }

        public EmployeesProductsDTO? GetEmployeesProducts()
        {
            return _repository.GetEmployeesProducts();
        }
    }
}
