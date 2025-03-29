using ADONET.DTO;
using ADONET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        AppUserService _AppUserService;
        public AppUserController()
        {
            _AppUserService = new AppUserService();
        }

        [HttpPost("AddAppUser")]
        public int AddAppUser([FromBody] AppUserDTO user)
        {
            return _AppUserService.AddAppUser(user);
        }
    }
}
