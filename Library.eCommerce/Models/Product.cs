namespace Spring2025_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String? Name { get; set; }

        public string? Display
        {
            get
            {
                return $"{Id}. {Name}";
            }
        }
        public Product()
        {
            Name = string.Empty; 
        }

        public Product(Product p)
        {
            Id = p.Id;
            Name = p.Name;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}
