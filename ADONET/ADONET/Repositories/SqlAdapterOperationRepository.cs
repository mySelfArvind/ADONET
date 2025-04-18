using ADONET.DTO;
using ADONET.SqlHelpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADONET.Repositories
{
    public class SqlAdapterOperationRepository
    {
        SqlConnection _connection;
        public SqlAdapterOperationRepository()
        {
            _connection = SqlHelper.GetConnection();
        }

        //1. Reading data using SqlAdapter normal query;
        public List<AppUserDTO>? GetAllAppUsers()
        {
            List<AppUserDTO>? users = new();
            using (_connection)
            {
                string query = "select * from AppUsers";
                SqlDataAdapter da = new SqlDataAdapter(query, _connection);
                DataSet ds = new();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataTable tables in ds.Tables)
                    {
                        foreach (DataRow dr in tables.Rows)
                        {
                            users.Add(new AppUserDTO()
                            {
                                UserId = Convert.ToInt32(dr[0]),
                                FirstName = Convert.ToString(dr[1]),
                                LastName = Convert.ToString(dr[2]),
                                EmailId = Convert.ToString(dr[3]),
                                Password = Convert.ToString(dr[4])
                            });
                        }
                    }
                }
            }
            return users;
        }
        //2. Reading data using SqlAdapter normal query with parameter;
        public AppUserDTO? GetAppUsersById(int id)
        {
            AppUserDTO? user = null;
            using (_connection)
            {
                string query = "select * from AppUsers where UserId=@id";
                SqlDataAdapter da = new SqlDataAdapter(query, _connection);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataSet ds = new();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataTable tables in ds.Tables)
                    {
                        foreach (DataRow rows in tables.Rows)
                        {
                            user = new AppUserDTO()
                            {
                                UserId = Convert.ToInt32(rows[0]),
                                FirstName = Convert.ToString(rows[1]),
                                LastName = Convert.ToString(rows[2]),
                                EmailId = Convert.ToString(rows[3]),
                                Password = Convert.ToString(rows[4])
                            };
                        }
                    }
                }

            }
            return user;
        }
        //3. Reading data using SqlAdapter stored procedure;
        public List<AppUserDTO>? GetAllAppUsersProc()
        {
            List<AppUserDTO>? users = new();
            using (_connection)
            {
                SqlDataAdapter da = new("GetAllAppUsers", _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataTable tables in ds.Tables)
                    {
                        foreach(DataRow dr in tables.Rows)
                        {
                            users.Add(new AppUserDTO()
                            {
                                UserId = Convert.ToInt32(dr[0]),
                                FirstName = Convert.ToString(dr[1]),
                                LastName = Convert.ToString(dr[2]),
                                EmailId = Convert.ToString(dr[3]),
                                Password = Convert.ToString(dr[4])
                            });
                        }
                    }
                }
            }
            return users;
        }
        //4. Reading data using SqlAdapter stored procedure with parameter;
        public List<AppUserDTO>? GetAllAppUsersByIdProc(int id)
        {
            List<AppUserDTO>? users = new() ;
            using (_connection)
            {
                SqlDataAdapter da = new("GetAppUsersById", _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataSet ds = new();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataTable tables in ds.Tables)
                    {
                        foreach (DataRow dr in tables.Rows)
                        {
                            users.Add(new AppUserDTO()
                            {
                                UserId = Convert.ToInt32(dr[0]),
                                FirstName = Convert.ToString(dr[1]),
                                LastName = Convert.ToString(dr[2]),
                                EmailId = Convert.ToString(dr[3]),
                                Password = Convert.ToString(dr[4])
                            });
                        }
                    }
                }
            }
            return users;
        }
    }
}