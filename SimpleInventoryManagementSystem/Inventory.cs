using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimpleInventoryManagementSystem
{
    public class Inventory
    {
        private static List<Product> inventory = new List<Product>();

        public Inventory() { }

        public void AddProduct()
        {
            string name;
            int price, quantity;
            try
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("\nPrice: ");
                price = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nQuantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e){
                Console.WriteLine("\nError occured in inputting the new product information\n");
                Console.WriteLine(e);
                return;
            }
            Product product = new Product(name, price, quantity);
            inventory.Add(product);
            Console.WriteLine("\nAdded product successfully");
        }
        public void ViewAllProducts()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("There are currently no products in the inventory");
            }
            else
            {
                foreach (Product product in inventory)
                {
                    Console.WriteLine(product);
                }
            }

        }
        public void UpdateProduct()
        {
            Console.Write("Enter Product Name: ");
            string ?name = Console.ReadLine();
            Product selectedProduct = null;
            foreach(Product product in inventory)
            {
                if (product.Name == name)
                {
                    selectedProduct = product;
                }
            }
            if(selectedProduct == null)
            {
                Console.WriteLine("\nProduct was not found in the inventory");
                return;
            }
            Console.WriteLine(selectedProduct);
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
            Console.WriteLine($"Product information updated successfully!\n{selectedProduct.ToString()}");
        }
        public void DeleteProduct()
        {
            if(inventory.Count == 0)
            {
                Console.WriteLine("There are currently no produts in the inventory");
                return;
            }
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();
            Product selectedProduct = null;
            foreach (Product product in inventory)
            {
                if (product.Name == name)
                {
                    selectedProduct = product;
                }
            }
            if (selectedProduct == null)
            {
                Console.WriteLine("\nProduct was not found in the inventory");
                return;
            }
            Console.WriteLine(selectedProduct);
            Console.WriteLine("Delete Product?\n1-Yes\n2-No");
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    inventory.Remove(selectedProduct);
                    Console.WriteLine("Product removed successfully\n");
                    break;
                case 2:
                    return;
            }
        }
    }
}
