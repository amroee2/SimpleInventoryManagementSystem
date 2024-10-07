using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleInventoryManagementSystem
{
    public class NoSqlDB : IDatabase
    {

        IMongoDatabase database = ConnectionInitializer.InitializeMongoConnection();


        public void AddProduct(Product product)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                product.Id = MaxProductId() + 1;
                collection.InsertOne(product);
                Console.WriteLine("Product added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var filter = Builders<Product>.Filter.Eq("Name", product.Name);
                collection.DeleteOne(filter);
                Console.WriteLine("Product deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
            }
        }

        public void UpdateProduct(Product newProduct, string oldName)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var filter = Builders<Product>.Filter.Eq("Name", oldName);
                var update = Builders<Product>.Update
                    .Set("Name", newProduct.Name)
                    .Set("Price", newProduct.Price)
                    .Set("Quantity", newProduct.Quantity);
                collection.UpdateOne(filter, update);
                Console.WriteLine("Product updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
            }
        }

        public Product SearchForProduct(string name)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var filter = Builders<Product>.Filter.Eq("Name", name);
                var product = collection.Find(filter).FirstOrDefault();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching for product: {ex.Message}");
                return null;
            }
        }

        public void ViewAllProducts()
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var products = collection.Find(new BsonDocument()).ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing products: {ex.Message}");
            }
        }

        public int MaxProductId()
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var maxProduct = collection.Find(new BsonDocument())
                    .Sort(Builders<Product>.Sort.Descending("Id"))
                    .Limit(1)
                    .FirstOrDefault();
                return maxProduct != null ? maxProduct.Id : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting max product ID: {ex.Message}");
                return 0;
            }
        }

    }
}
