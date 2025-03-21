using ADONET.DTO;
using Microsoft.Data.SqlClient;
namespace ADONET.Repositories
{
    public class EmployeeRepository
    {
        /// <summary>
        /// get closed SqlConnection object, need to open and close manually...
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);
            IConfigurationRoot config = builder.Build();
            string? CS = config.GetConnectionString("AppDb");
            SqlConnection connection = new SqlConnection(CS);

            return connection;

        }

        /// <summary>
        /// returning all the employees...
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            SqlConnection connection = GetConnection();
            string Query = "SELECT * FROM Employees";
            SqlCommand cmd = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                employees.Add(new EmployeeDTO()
                {
                    EmployeeId = rdr.GetInt32(0),
                    FirstName = rdr.GetString(1),
                    LastName = rdr.GetString(2),
                    Age = rdr.GetInt32(3),
                    Position = rdr.GetString(4),
                    Department = rdr.GetString(5),
                    HireDate = rdr.GetDateTime(6),
                    Salary = rdr.GetDecimal(7)
                });
            }
            connection.Close();
            return employees;
        }
    }
}
