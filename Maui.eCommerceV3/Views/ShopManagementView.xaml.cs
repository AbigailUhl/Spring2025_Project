using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.eCommerceV3.ViewModels;
using Microsoft.Maui.Controls;

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
        (BindingContext as ShopManagementViewModel).PurchaseItem();
    }

    private void RemoveFromCartClicked(object sender, EventArgs e)
    {
        (BindingContext as ShopManagementViewModel).ReturnItem();
    }

    private void InLineAddClicked(object sender, EventArgs e)
    {
        (BindingContext as ShopManagementViewModel).RefreshUX();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}