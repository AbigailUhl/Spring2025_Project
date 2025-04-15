using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.eCommerceV3.ViewModels;

namespace Maui.eCommerceV3.Views;

public partial class ShopManagementView : ContentPage
{
    public ShopManagementView()
    {
        InitializeComponent();
        BindingContext = new ShopManagementViewModel();
    }

    private void AddToCartClicked(object sender, EventArgs e)
    {
        
    }
}