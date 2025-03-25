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

        /// <summary>
        /// Demonstrating the use-case of ExecuteScalar method [fetching the count of total users]
        /// </summary>
        /// <returns></returns>
        public int TotalEmployees()
        {
            using (SqlConnection connection = GetConnection())
            {

                string Query = "select count(EmployeeID) from Employees";
                SqlCommand cmd = new SqlCommand(Query, connection);
                connection.Open();
                int TotalEmployees = Convert.ToInt32(cmd.ExecuteScalar());
                return TotalEmployees;
            }
        }

        /// <summary>
        /// Demonstrating the use-case of ExecuteNonQuery method [Adding new users]
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string AddNewEmployee(EmployeeDTO employee)
        {
            string Message = "Something Went Wrong";
            using(SqlConnection connection = GetConnection())
            {
                string Query = $"INSERT INTO Employees(EmployeeId,FirstName,LastName,Age,Position,Department,HireDate,Salary) VALUES({employee.EmployeeId},'{employee.FirstName}','{employee.LastName}',{employee.Age},'{employee.Position}','{employee.Department}','{employee.HireDate.ToString("yyyy-MM-dd")}',{employee.Salary})";
                SqlCommand cmd = new SqlCommand (Query, connection);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Message = "Employee Added Successfully";
                return Message;
            }
        }
    }
}
