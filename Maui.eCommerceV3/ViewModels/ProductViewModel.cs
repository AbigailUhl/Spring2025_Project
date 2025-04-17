using Spring2025_Project.Models;
using Library.eCommerce.Services;
using Library.eCommerce.Models;

namespace Maui.eCommerceV3.ViewModels;

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

    public ProductViewModel()
    {
        Model = new Item();
        cachedModel = null;
    }

    public void AddOrUpdate()
    {
        ProductServiceProxy.Current.AddOrUpdate(Model);
    }

    public ProductViewModel(Item? model)
    {
        Model = model;
        if (model != null)
        {
            cachedModel = new Item(model);
        }
    }

    public void Undo()
    {
       ProductServiceProxy.Current.AddOrUpdate(cachedModel);
    }
} 