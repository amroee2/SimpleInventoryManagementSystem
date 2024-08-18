using SimpleInventoryManagementSystem;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
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
                }
            }
        }
    }
}