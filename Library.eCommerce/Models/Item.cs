using Spring2025_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.eCommerce.DTO;
using Library.eCommerce.Services;


namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int? Quantity { get; set; }
        public int InlineQuantity { get; set; } = 1;
        public override string ToString()
        {
            return $"{Product} Quantity:{Quantity}";
        }
        public string Display
        {
            get
            {
                return $"{Product?.Display ?? string.Empty} Quantity: {Quantity}";
            }
        }
        public Item()
        {
            Product = new ProductDTO();
            Quantity = 0;
        }
        public Item(Item i)
        {
            Product = new ProductDTO(i.Product);
            Quantity = i.Quantity;
            Id = i.Id;
        }
    }
}
