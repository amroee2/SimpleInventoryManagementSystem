using SimpleInventoryManagementSystem;
using System.Data.SqlClient;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Inventory inventory = new Inventory(new SqlDB());
            Console.WriteLine("**** Welcome ****");
            while (true)
            {
                Console.WriteLine("1-Add a product\n2-View all products\n3-Edit a product\n" +
                    "4-Delete a product\n5-Search for a product\n0-Close the program\n");
                int operation = Convert.ToInt32(Console.ReadLine());

                switch (operation)
                {
                    case 0:
                        Console.WriteLine("Closing Program\n");
                        return;
                    case 1:
                        inventory.AddProduct();
                        break;
                    case 2:
                        inventory.ViewAllProducts();
                        break;
                    case 3:
                        inventory.UpdateProduct();
                        break;
                    case 4:
                        inventory.DeleteProduct();
                        break;
                    case 5:
                        Console.WriteLine("Enter product name:");
                        string? name = Console.ReadLine();
                        Product product = inventory.SearchForProduct(name);
                        if (product == null)
                        {
                            Console.WriteLine("\nProduct was not found in the inventory");
                        }
                        else
                        {
                            Console.WriteLine(product);
                        }
                        break;
                }
            }
        }
    }
}