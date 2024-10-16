namespace SimpleInventoryManagementSystem
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task UpdateProductAsync(Product newProduct, string oldName);
        Task<Product> SearchForProductAsync(string name);
        Task ViewAllProductsAsync();
    }
}
