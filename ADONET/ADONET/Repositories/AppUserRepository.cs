using ADONET.DTO;
using ADONET.SqlHelpers;
using Microsoft.Data.SqlClient;

namespace ADONET.Repositories
{
    public class AppUserRepository
    {
        SqlConnection _connection;
        public AppUserRepository()
        {
            _connection = SqlHelper.GetConnection();
        }

        public int AddAppUser(AppUserDTO user)
        {
            int UserId;
            SqlCommand cmd = new SqlCommand("InsertAppUsers", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            SqlParameter outputParameter = new();
            outputParameter.ParameterName = "@UserId";
            outputParameter.DbType = System.Data.DbType.Int32;
            outputParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outputParameter);
            _connection.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
                return Convert.ToInt32(outputParameter.Value);
            return 0;
        }
    }
}
