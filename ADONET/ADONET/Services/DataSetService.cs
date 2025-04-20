using ADONET.Repositories;

namespace ADONET.Services
{
    public class DataSetService
    {
        DataSetRepository _repository;
        public DataSetService()
        {
            _repository = new DataSetRepository();
        }

        public string SqlBulkCopy()
        {
            return _repository.SqlBulkCopy();
        }

        public string BulkCopyFromOneTableToAnother()
        {
            return _repository.BulkCopyFromOneTableToAnother();
        }
    }
}
