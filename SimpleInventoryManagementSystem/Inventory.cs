using System.Runtime.CompilerServices;

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
            Console.WriteLine("\nAdd product successfully");
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
    }
}
