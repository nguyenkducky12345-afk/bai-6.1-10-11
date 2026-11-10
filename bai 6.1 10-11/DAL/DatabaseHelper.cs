using System.Data.SqlClient;

namespace RetailSalesSystem.DAL
{
    public class DatabaseHelper
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SieuthiDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}