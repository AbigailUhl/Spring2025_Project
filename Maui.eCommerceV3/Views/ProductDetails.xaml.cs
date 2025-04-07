using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.eCommerceV3.ViewModels;

namespace Maui.eCommerceV3.Views;

public partial class ProductDetails : ContentPage
{
    public ProductDetails()
    {
        InitializeComponent();
        BindingContext = new ProductViewModel();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryManagement");
    }
}