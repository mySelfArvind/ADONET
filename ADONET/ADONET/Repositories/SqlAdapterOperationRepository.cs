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
        //4. Reading data using SqlAdapter stored procedure with parameter;
        public List<AppUserDTO>? GetAllAppUsersByIdProc(int id)
        {
            List<AppUserDTO>? users = new();
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

        //5. returning 2 or more than two result set;
        public EmployeesProductsDTO? GetEmployeesProducts()
        {
            EmployeesProductsDTO employees_products = new();
            List<EmployeeDTO> employees = new();
            List<ProductDTO> products = new();
            using (_connection)
            {
                SqlDataAdapter da = new("USP_EmployeesProducts", _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new();
                da.Fill(ds);
                ds.Tables[0].TableName = "Employees";
                ds.Tables[1].TableName = "Products";

                foreach (DataTable tables in ds.Tables)
                {
                    if(tables.TableName == "Employees")
                    {
                        foreach(DataRow dr in tables.Rows)
                        {
                            employees?.Add(new EmployeeDTO()
                            {
                                EmployeeId = Convert.ToInt32(dr[0]),
                                FirstName = Convert.ToString(dr[1]),
                                LastName = Convert.ToString(dr[2]),
                                Age = Convert.ToInt32(dr[3]),
                                Position = Convert.ToString(dr[4]),
                                Department = Convert.ToString(dr[5]),
                                HireDate = Convert.ToDateTime(dr[6]),
                                Salary = Convert.ToDecimal(dr[7])
                            });
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in tables.Rows)
                        {
                            products?.Add(new ProductDTO()
                            {
                                ProductId = Convert.ToInt32(dr[0]),
                                ProductName = Convert.ToString(dr[1]),
                                Brand = Convert.ToString(dr[2]),
                                Category = Convert.ToString(dr[3]),
                                Price = Convert.ToDecimal((decimal)dr[4]),
                                Description = Convert.ToString(dr[5]),
                                StockQuantity = Convert.ToInt32(dr[6]),
                                WarrantyPeriod = Convert.ToString(dr[7]),
                                Color = Convert.ToString(dr[8]),
                                ScreenSize = Convert.ToString(dr[9]),
                                Storage = Convert.ToString(dr[10]),
                                Processor = Convert.ToString(dr[11]),
                                BatteryCapacity = Convert.ToString(dr[12])
                            });
                        }
                    }
                }
            }
            employees_products.Employees = employees;
            employees_products.Products = products;
            return employees_products;
        }
    }
}