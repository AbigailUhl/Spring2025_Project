using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Maui.eCommerceV3.ViewModels;

namespace Maui.eCommerceV3.Views;

public partial class InventoryManagementView : ContentPage
{
    public InventoryManagementView()
    {
        InitializeComponent();
        BindingContext = new InventoryManagementViewModel();
    }
    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.Delete();
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    
    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Product");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var productId = (BindingContext as InventoryManagementViewModel)?.SelectedProduct?.Id;
        Shell.Current.GoToAsync($"//Product?productId={productId}");
        
    }
    
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
    }
    
    private void SortChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        var selected = picker?.SelectedItem?.ToString();

        var vm = BindingContext as InventoryManagementViewModel;
        if (vm != null && !string.IsNullOrEmpty(selected))
        {
            vm.SortOption = selected;
            vm.NotifyPropertyChanged(nameof(vm.Products));
        }
    }
    private async void ShowSortOptions(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Sort Inventory By", "Cancel", null,
            "Alphabetical (A-Z)",
            "Price: Low to High",
            "Price: High to Low");

        if (action == "Cancel" || string.IsNullOrEmpty(action))
            return;

        var vm = BindingContext as InventoryManagementViewModel;
        if (vm != null)
        {
            vm.SortOption = action;
            vm.NotifyPropertyChanged(nameof(vm.Products));
        }
    }
}