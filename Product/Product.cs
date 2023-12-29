namespace CourseWork.Product
{
    public class Product
    {
        public string Name { get; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }
        // TODO purpose / category  and ID

        public Product(string name, float price, string description, int amount)
        {
            Name = name;
            Price = price;
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            return Name + "  | price: " + Price + "$  | " + Description + "  | " + Amount + " left.";
        }
    }
}