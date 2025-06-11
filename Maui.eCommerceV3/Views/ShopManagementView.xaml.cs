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
        (BindingContext as ShopManagementViewModel).PurchaseItem();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ShopManagementViewModel)?.RefreshUX();
    }
    private async void ShowSortOptions(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Sort Inventory By", "Cancel", null,
            "Alphabetical (A-Z)",
            "Price: Low to High",
            "Price: High to Low");

        if (action == "Cancel" || string.IsNullOrEmpty(action))
            return;

        var vm = BindingContext as ShopManagementViewModel;
        if (vm != null)
        {
            vm.SortOption = action;
            vm.NotifyPropertyChanged(nameof(vm.Inventory));
            vm.NotifyPropertyChanged(nameof(vm.ShoppingCart));
        }
    }

    private void BuyClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Checkout");
    }
}