using Library.eCommerce.DTO;

namespace Spring2025_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public decimal Price { get; set; }

        public string? Display
        {
            get
            {
                return $"{Id}. {Name}";
            }
        }
        public string LegacyProperty1 { get; set; }
        public string LegacyProperty2 { get; set; }
        public string LegacyProperty3 { get; set; }
        public string LegacyProperty4 { get; set; }
        public string LegacyProperty5 { get; set; }
        public string LegacyProperty6 { get; set; }
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
        public Product(ProductDTO p)
        {
            Name = p.Name;
            Id = p.Id;
            LegacyProperty1 = string.Empty;
        }
    }
}
