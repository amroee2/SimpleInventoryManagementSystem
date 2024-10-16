using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleInventoryManagementSystem
{
    public class MongoProductRepository : IProductRepository
    {

        IMongoDatabase database = ConnectionInitializer.InitializeMongoConnection();


        public async Task AddProductAsync(Product product)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                product.Id = await MaxProductIdAsync() + 1;
                await collection.InsertOneAsync(product);
                Console.WriteLine("Product added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
            }
        }


        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var filter = Builders<Product>.Filter.Eq("Name", product.Name);
                await collection.DeleteOneAsync(filter);
                Console.WriteLine("Product deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
            }
        }

        public async Task UpdateProductAsync(Product newProduct, string oldName)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var filter = Builders<Product>.Filter.Eq("Name", oldName);
                var update = Builders<Product>.Update
                    .Set("Name", newProduct.Name)
                    .Set("Price", newProduct.Price)
                    .Set("Quantity", newProduct.Quantity);
                await collection.UpdateOneAsync(filter, update);
                Console.WriteLine("Product updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
            }
        }

        public async Task<Product> SearchForProductAsync(string name)
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var filter = Builders<Product>.Filter.Eq("Name", name);
                var product = await collection.Find(filter).FirstOrDefaultAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching for product: {ex.Message}");
                return null;
            }
        }

        public async Task ViewAllProductAsync()
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var products = await collection.Find(new BsonDocument()).ToListAsync();
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

        public async Task<int> MaxProductIdAsync()
        {
            try
            {
                var collection = database.GetCollection<Product>("products");
                var maxProduct = await collection.Find(new BsonDocument())
                    .Sort(Builders<Product>.Sort.Descending("Id"))
                    .Limit(1)
                    .FirstOrDefaultAsync();
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
