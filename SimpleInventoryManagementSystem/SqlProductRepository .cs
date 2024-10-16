using System.Data.SqlClient;
using System.Text;

namespace SimpleInventoryManagementSystem
{
    public class SqlDB : IProductRepository
    {
        public static SqlConnection _conn = ConnectionInitializer.InitializSqlConnection();
        public void AddProduct(Product product)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("INSERT INTO Products (Name, Price, Quantity) VALUES");
            stringBuilder.Append($"('{product.Name}', {product.Price}, {product.Quantity})");
            string query = stringBuilder.ToString();
            SqlCommand command = new SqlCommand(query, _conn);
            command.ExecuteNonQuery();
            Console.WriteLine("\nAdded product successfully");
        }

        public void DeleteProduct(Product product)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM Products WHERE Name = ");
            stringBuilder.Append($"'{product.Name}'");
            string query = stringBuilder.ToString();
            SqlCommand command = new SqlCommand(query, _conn);
            command.ExecuteNonQuery();
            Console.WriteLine("\nDeleted product successfully");
        }

        public void UpdateProduct(Product newProduct, string oldName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE Products SET ");
            stringBuilder.Append($"Price = {newProduct.Price}, ");
            stringBuilder.Append($"Quantity = {newProduct.Quantity}, ");
            stringBuilder.Append($"Name = '{newProduct.Name}' ");
            stringBuilder.Append($"WHERE Name = '{oldName}'");
            string query = stringBuilder.ToString();

            SqlCommand command = new SqlCommand(query, _conn);
            command.ExecuteNonQuery();
            Console.WriteLine("\nUpdated product successfully");
        }

        public Product SearchForProduct(string name)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM Products WHERE Name = ");
            stringBuilder.Append($"'{name}'");
            string query = stringBuilder.ToString();
            SqlCommand command = new SqlCommand(query, _conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                string productName = reader.GetString(1);
                int price = reader.GetInt32(2);
                int quantity = reader.GetInt32(3);
                Product product = new Product(productName, price, quantity);
                product.Id = id;

                reader.Close();
                return product;
            }
            reader.Close();
            return null;
        }

        public void ViewAllProducts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM Products");
            string query = stringBuilder.ToString();
            SqlCommand command = new SqlCommand(query, _conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string productName = reader.GetString(1);
                    int price = reader.GetInt32(2);
                    int quantity = reader.GetInt32(3);
                    Product product = new Product(productName, price, quantity);
                    product.Id = id;
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("There are currently no products in the inventory");
            }
            reader.Close();
        }
    }
}
