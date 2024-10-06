using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem
{
    public class ConnectionInitializer
    {

        public static SqlConnection InitializConnection()
        {
            Console.WriteLine("Getting Connection");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryManagementSystem;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
