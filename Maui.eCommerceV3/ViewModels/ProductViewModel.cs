using Spring2025_Project.Models;
using Library.eCommerce.Services;
using Library.eCommerce.Models;

namespace Maui.eCommerceV3.ViewModels
{
    public class ProductViewModel
    {
        private Item? cachedModel { get; set; }

        public string? Name
        {
            get
            {
                return Model?.Product?.Name ?? string.Empty;
            }
            set
            {
                if (Model != null && Model.Product?.Name != value)
                {
                    Model.Product.Name = value;
                }
            }
        }

        public int? Quantity
        {
            get
            {
                return Model?.Quantity; 
            }
            set
            {
                if (Model != null && Model.Quantity != value)
                {
                    Model.Quantity = value;
                }
            }
        }

        public Item? Model { get; set; }
        public void AddOrUpdate()
        {
            ProductServiceProxy.Current.AddOrUpdate(Model);
        }
        public void Undo()
        {
            ProductServiceProxy.Current.AddOrUpdate(cachedModel);
        }
        public ProductViewModel()
        {
            Model = new Item();
            cachedModel = null;
        }
        public ProductViewModel(Item? model)
        {
            Model = model;
            if (model != null)
            {
                cachedModel = new Item(model);
            }
        }
        
        public decimal? Price
        {
            get => Model?.Product?.Price ?? 0;
            set
            {
                if (Model != null && Model.Product != null && Model.Product.Price != value)
                {
                    Model.Product.Price = value ?? 0;
                }
            }
        }
    }
} 