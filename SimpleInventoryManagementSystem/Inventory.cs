﻿namespace SimpleInventoryManagementSystem
{
    public class Inventory
    {
        IDatabase _database;
        public Inventory(IDatabase database)
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
                Product selectedProduct = _database.SearchForProduct(name);
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

            _database.AddProduct(newProduct);
        }
        public void UpdateProduct()
        {
            Console.Write("Enter Product Name: ");
            string? name = Console.ReadLine();
            Product selectedProduct = _database.SearchForProduct(name);
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
            _database.UpdateProduct(selectedProduct, name);
        }
        public void DeleteProduct()
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();
            Product selectedProduct = _database.SearchForProduct(name);
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
                    _database.DeleteProduct(selectedProduct);
                    break;
                case 2:
                    return;
            }
        }
    }
}
