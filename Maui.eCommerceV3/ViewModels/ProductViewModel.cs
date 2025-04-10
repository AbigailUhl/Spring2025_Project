using Spring2025_Project.Models;

namespace Maui.eCommerceV3.ViewModels;

public class ProductViewModel
{
    public string? Name
    {
        get
        {
            return Model?.Name ?? string.Empty;
        }
        set
        {
            if (Model != null && Model.Name != value)
            {
                Model.Name = value;
            }
        }
    }
    
    public Product? Model { get; set; }

    public ProductViewModel()
    {
        Model = new Product();
    }

    public ProductViewModel(Product? model)
    {
        Model = model;
    }
} 