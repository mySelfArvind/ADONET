using Microsoft.Data.SqlClient;

namespace ADONET.SqlHelpers
{
    public class SqlHelper
    {
        public static SqlConnection GetConnection()
        {
            string? CS = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("AppDb");
            return new SqlConnection(CS);
        }
    }
}
