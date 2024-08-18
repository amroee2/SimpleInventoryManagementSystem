using SimpleInventoryManagementSystem;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Console.WriteLine("**** Welcome ****");

            Console.WriteLine("1-Add a product\n 2-View all products\n 3-Edit a product\n" +
                " 4-Delete a product\n5-Search for a product\n 0-Close the program");

            int operation = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (operation)
                {
                    case 0:
                        Console.WriteLine("Closing Program\n");
                        break;
                }
            }
        }
    }
}