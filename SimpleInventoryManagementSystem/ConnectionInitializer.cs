using MongoDB.Driver;
using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem
{
    public class ConnectionInitializer
    {
        public static SqlConnection InitializSqlConnection()
        {
            Console.WriteLine("Getting Connection");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryManagementSystem;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        public static IMongoDatabase InitializeMongoConnection()
        {
            try
            {
                Console.WriteLine("Getting MongoDB Connection");
                string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("InventoryManagementSystem");
                Console.WriteLine("Connected to MongoDB");
                return database;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to MongoDB: {ex.Message}");
                throw;
            }
        }
    }
}
