using ADONET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        DataSetService _service;
        public DataSetController()
        {
            _service = new DataSetService();
        }

        [HttpGet]
        [Route("LoadXmlInSqlTable")]
        public string SqlBulkCopy()
        {
            return _service.SqlBulkCopy();
        }
    }
}
