using ADONET.DTO;
using ADONET.SqlHelpers;
using Microsoft.Data.SqlClient;

namespace ADONET.Repositories
{
    public class OtherRepository
    {
        SqlConnection _connection;
        public OtherRepository()
        {
            _connection = SqlHelper.GetConnection();
        }


        public EmployeeAndAppUserDTO GetEmployeesAndAppUsers()
        {
            EmployeeAndAppUserDTO EmployeeAndAppUser = new();
            List<EmployeeDTO> employees = new();
            List<AppUserDTO> appUsers = new();
            string Query = "select * from Employees; select * from AppUsers;";
            SqlCommand cmd = new SqlCommand(Query, _connection);
            _connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                employees.Add(new EmployeeDTO
                {
                    EmployeeId = rdr.GetInt32(0),
                    FirstName = rdr.GetString(1).ToString(),
                    LastName = rdr.GetString(2).ToString(),
                    Age = rdr.GetInt32(3),
                    Position = rdr.GetString(4).ToString(),
                    Department = rdr.GetString(5).ToString(),
                    HireDate = rdr.GetDateTime(6),
                    Salary = rdr.GetDecimal(7)
                });
            }
            if (rdr.NextResult()) //checking if result-set has any more result.
            {
                while (rdr.Read())
                {

                    appUsers.Add(new AppUserDTO()
                    {
                        UserId = rdr.GetInt32(0),
                        FirstName = rdr.GetString(1).ToString(),
                        LastName = rdr.GetString(2).ToString(),
                        EmailId = rdr.GetString(3).ToString(),
                        Password = rdr.GetString(4).ToString()
                    });
                }
            }

            EmployeeAndAppUser.Employees = employees;
            EmployeeAndAppUser.AppUsers = appUsers;

            return EmployeeAndAppUser;
        }

    }
}
