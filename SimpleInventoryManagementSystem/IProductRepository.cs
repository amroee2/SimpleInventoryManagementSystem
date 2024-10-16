namespace SimpleInventoryManagementSystem
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product newProduct, string oldName);
        Product SearchForProduct(string name);
        void ViewAllProducts();
    }
}
