using Microsoft.Data.SqlClient;
using ADONET.SqlHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ADONET.DTO;

namespace ADONET.Repositories
{
    public class ProductRepository
    {
        SqlConnection _conection;
        public ProductRepository()
        {
            _conection = SqlHelper.GetConnection();
        }

        public List<ProductDTO> SearchProductWithName(string productName)
        {
            List<ProductDTO> products = new();
            string Query = $"SELECT * FROM Products WHERE ProductName LIKE '{productName}%'";
            SqlCommand cmd = new SqlCommand(Query, _conection);
            _conection.Open();
            SqlDataReader? rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                products.Add(new ProductDTO
                {
                    ProductId = rdr.GetInt32(0),
                    ProductName = rdr.GetString(1).ToString(),
                    Brand = rdr.GetString(2).ToString(),
                    Category = rdr.GetString(3).ToString(),
                    Price = rdr.GetDecimal(4),
                    Description = rdr.GetString(5).ToString(),
                    StockQuantity = rdr.GetInt32(6),
                    WarrantyPeriod = rdr.GetString(7),
                    Color = rdr.GetString(8).ToString(),
                    ScreenSize = rdr.IsDBNull(rdr.GetOrdinal("ScreenSize")) ? string.Empty : rdr.GetString(9).ToString(),
                    Storage = rdr.IsDBNull(rdr.GetOrdinal("Storage")) ? string.Empty : rdr.GetString(10).ToString(),
                    Processor = rdr.IsDBNull(rdr.GetOrdinal("Processor")) ? string.Empty : rdr.GetString(11).ToString(),
                    BatteryCapacity= rdr.IsDBNull(rdr.GetOrdinal("BatteryCapacity")) ? string.Empty : rdr.GetString(12).ToString()
                });
            }
            return products;
        }

        /// <summary>
        /// prevent sql injection using parameterized query;;
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public List<ProductDTO> SearchProductWithNameUsingParameterizedQuery(string productName)
        {
            List<ProductDTO> products = new();
            string Query = $"SELECT * FROM Products WHERE ProductName LIKE @ProductName";
            SqlCommand cmd = new SqlCommand(Query, _conection);
            cmd.Parameters.AddWithValue("@ProductName", productName + "%");
            _conection.Open();
            SqlDataReader? rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                products.Add(new ProductDTO
                {
                    ProductId = rdr.GetInt32(0),
                    ProductName = rdr.GetString(1).ToString(),
                    Brand = rdr.GetString(2).ToString(),
                    Category = rdr.GetString(3).ToString(),
                    Price = rdr.GetDecimal(4),
                    Description = rdr.GetString(5).ToString(),
                    StockQuantity = rdr.GetInt32(6),
                    WarrantyPeriod = rdr.GetString(7),
                    Color = rdr.GetString(8).ToString(),
                    ScreenSize = rdr.IsDBNull(rdr.GetOrdinal("ScreenSize")) ? string.Empty : rdr.GetString(9).ToString(),
                    Storage = rdr.IsDBNull(rdr.GetOrdinal("Storage")) ? string.Empty : rdr.GetString(10).ToString(),
                    Processor = rdr.IsDBNull(rdr.GetOrdinal("Processor")) ? string.Empty : rdr.GetString(11).ToString(),
                    BatteryCapacity = rdr.IsDBNull(rdr.GetOrdinal("BatteryCapacity")) ? string.Empty : rdr.GetString(12).ToString()
                });
            }
            return products;
        }

        /// <summary>
        /// prevent sql injection using stored procedures;;
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public List<ProductDTO> SearchProductWithNameUsingStoredProcedure(string productName)
        {
            List<ProductDTO> products = new();
            string Query = $"GetAllProductsByName";
            SqlCommand cmd = new SqlCommand(Query, _conection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", productName);
            _conection.Open();
            SqlDataReader? rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                products.Add(new ProductDTO
                {
                    ProductId = rdr.GetInt32(0),
                    ProductName = rdr.GetString(1).ToString(),
                    Brand = rdr.GetString(2).ToString(),
                    Category = rdr.GetString(3).ToString(),
                    Price = rdr.GetDecimal(4),
                    Description = rdr.GetString(5).ToString(),
                    StockQuantity = rdr.GetInt32(6),
                    WarrantyPeriod = rdr.GetString(7),
                    Color = rdr.GetString(8).ToString(),
                    ScreenSize = rdr.IsDBNull(rdr.GetOrdinal("ScreenSize")) ? string.Empty : rdr.GetString(9).ToString(),
                    Storage = rdr.IsDBNull(rdr.GetOrdinal("Storage")) ? string.Empty : rdr.GetString(10).ToString(),
                    Processor = rdr.IsDBNull(rdr.GetOrdinal("Processor")) ? string.Empty : rdr.GetString(11).ToString(),
                    BatteryCapacity = rdr.IsDBNull(rdr.GetOrdinal("BatteryCapacity")) ? string.Empty : rdr.GetString(12).ToString()
                });
            }
            return products;
        }


    }
}
