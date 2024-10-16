namespace SimpleInventoryManagementSystem
{
    public class Inventory
    {
        IProductRepository _database;
        public Inventory(IProductRepository database)
        {
            _database = database;
        }

        public void AddProduct()
        {
            string name;
            int price, quantity;
            try
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                Product selectedProduct = _database.SearchForProductAsync(name).Result;
                if (selectedProduct != null)
                {
                    Console.WriteLine("Product already exists");
                    return;
                }
                Console.Write("\nPrice: ");
                price = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nQuantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError occured in inputting the new product information\n");
                Console.WriteLine(e);
                return;
            }
            Product newProduct = new Product(name, price, quantity);

            _database.AddProductAsync(newProduct);
        }
        public void UpdateProduct()
        {
            Console.Write("Enter Product Name: ");
            string? name = Console.ReadLine();
            Product selectedProduct = _database.SearchForProductAsync(name).Result;
            if (selectedProduct == null)
            {
                Console.WriteLine("\nProduct was not found in the inventory");
                return;
            }
            string newName;
            int newPrice, newQuantity;
            try
            {
                Console.Write("Name: ");
                newName = Console.ReadLine();
                Console.Write("\nPrice: ");
                newPrice = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nQuantity: ");
                newQuantity = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError occured in inputting the new product information\n");
                Console.WriteLine(e);
                return;
            }
            selectedProduct.Price = newPrice;
            selectedProduct.Quantity = newQuantity;
            selectedProduct.Name = newName;
            _database.UpdateProductAsync(selectedProduct, name);
        }
        public void DeleteProduct()
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();
            Product selectedProduct = _database.SearchForProductAsync(name).Result;
            if (selectedProduct == null)
            {
                Console.WriteLine("\nProduct was not found in the inventory");

                return;
            }
            Console.WriteLine("Delete Product?\n1-Yes\n2-No");
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    _database.DeleteProductAsync(selectedProduct);
                    break;
                case 2:
                    return;
            }
        }

        public void ViewAllProducts()
        {
            _database.ViewAllProductsAsync();
        }

        public Product SearchForProduct(string name)
        {
            return _database.SearchForProductAsync(name).Result;
        }
    }
}
