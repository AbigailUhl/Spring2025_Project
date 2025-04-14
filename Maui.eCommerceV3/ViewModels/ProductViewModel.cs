using Spring2025_Project.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerceV3.ViewModels;

public class ProductViewModel
{
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
    
    public Item? Model { get; set; }

    public ProductViewModel()
    {
        Model = new Item();
    }

    public void AddOrUpdate()
    {
        ProductServiceProxy.Current.AddOrUpdate(Model);
    }

    public ProductViewModel(Item? model)
    {
        Model = model;
    }
} 