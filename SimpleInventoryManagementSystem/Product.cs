namespace SimpleInventoryManagementSystem
{
    public class Product
    {
        public int Id { get; set; }
        private string? name;
        private int price;
        private int quantity;

        public string? Name
        {

            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0)
                    quantity = value;
            }
        }
        public Product(string name, int price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public override string ToString()
        {
            return $"Id = {this.Id}, Name = {this.Name}, Price = {this.Price}, Quantity = {this.Quantity}";
        }
    }
}
