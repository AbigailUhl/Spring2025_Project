using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Services;
using Maui.eCommerceV3.ViewModels;
using Spring2025_Project.Models;

namespace Maui.eCommerceV3.Views;

[QueryProperty(nameof(ProductId), "productId")]

public partial class ProductDetails : ContentPage
{
    public ProductDetails()
    {
        InitializeComponent();
    }
    
    public int ProductId { get; set; }
    
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ProductViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//InventoryManagement");
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        (BindingContext as ProductViewModel).Undo();
        Shell.Current.GoToAsync("//InventoryManagement");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (ProductId == 0)
        {
            BindingContext = new ProductViewModel();
        }
        else
        {
            BindingContext = new ProductViewModel(ProductServiceProxy.Current.GetById(ProductId));
        }
    }
}