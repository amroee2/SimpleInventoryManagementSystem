using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleInventoryManagementSystem
{
    public class MongoProductRepository : IProductRepository
    {

        IMongoDatabase _database;
        IMongoCollection<Product> _collection;

        public MongoProductRepository()
        {
            _database = ConnectionInitializer.InitializeMongoConnection();
            _collection = _database.GetCollection<Product>("products");
        }


        public async Task AddProductAsync(Product product)
        {
            try
            {
                product.Id = await MaxProductIdAsync() + 1;
                await _collection.InsertOneAsync(product);
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
                var filter = Builders<Product>.Filter.Eq("Name", product.Name);
                await _collection.DeleteOneAsync(filter);
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
                var filter = Builders<Product>.Filter.Eq("Name", oldName);
                var update = Builders<Product>.Update
                    .Set("Name", newProduct.Name)
                    .Set("Price", newProduct.Price)
                    .Set("Quantity", newProduct.Quantity);
                await _collection.UpdateOneAsync(filter, update);
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
                var filter = Builders<Product>.Filter.Eq("Name", name);
                var product = await _collection.Find(filter).FirstOrDefaultAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching for product: {ex.Message}");
                return null;
            }
        }

        public async Task ViewAllProductsAsync()
        {
            try
            {
                var products = await _collection.Find(new BsonDocument()).ToListAsync();
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
                var maxProduct = await _collection.Find(new BsonDocument())
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
