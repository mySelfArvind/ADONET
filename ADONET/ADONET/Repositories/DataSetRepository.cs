using ADONET.SqlHelpers;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ADONET.Repositories
{
    public class DataSetRepository
    {
        SqlConnection _connection;
        public DataSetRepository()
        {
            _connection = SqlHelper.GetConnection();
        }

        public string SqlBulkCopy()
        {
            using (_connection)
            {
                var xmlString = File.ReadAllText("SqlHelpers\\data.xml");
                var stringReader = new StringReader(xmlString);
                DataSet ds = new();
                ds.ReadXml(stringReader);
                _connection.Open();
                using(SqlBulkCopy bc = new SqlBulkCopy(_connection))
                {
                    bc.DestinationTableName = "Customers";
                    bc.ColumnMappings.Add("CustomerId", "CustomerId");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("EmailId", "EmailId");
                    bc.ColumnMappings.Add("Address", "Address");
                    bc.WriteToServer(ds.Tables["Customer"]);
                }

                using (SqlBulkCopy bc = new SqlBulkCopy(_connection))
                {
                    bc.DestinationTableName = "Orders";
                    bc.ColumnMappings.Add("OrderId", "OrderId");
                    bc.ColumnMappings.Add("Quantity", "Quantity");
                    bc.ColumnMappings.Add("Price", "Price");
                    bc.ColumnMappings.Add("CustomerId", "CustomerId");
                    bc.WriteToServer(ds.Tables["Order"]);
                }
            }
            return string.Empty;
        }
    }
}
