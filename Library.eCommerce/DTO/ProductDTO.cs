using Spring2025_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.eCommerce.DTO;

public class ProductDTO
{
    public int Id { get; set; }
    public String? Name { get; set; }
    public decimal Price { get; set; }
    public string? Display
    {
        get
        {
            return $"{Id}. {Name} - ${Price:F2}";
        }
    }
    public ProductDTO()
    {
        Name = string.Empty; 
    }
    
    public ProductDTO(Product p)
    {
        Name = p.Name;
        Id = p.Id;
        Price = p.Price;
    }

    public ProductDTO(ProductDTO p)
    {
        Id = p.Id;
        Name = p.Name;
        Price = p.Price;
    }

    public override string ToString()
    {
        return Display ?? string.Empty;
    }
}