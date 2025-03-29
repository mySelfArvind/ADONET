using ADONET.DTO;
using ADONET.Repositories;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace ADONET.Services
{
    public class AppUserService
    {
        AppUserRepository _AppUserRepository;
        public AppUserService()
        {
            _AppUserRepository = new AppUserRepository();
        }

        public int AddAppUser(AppUserDTO user)
        {
            return _AppUserRepository.AddAppUser(user);
        }
    }
}
