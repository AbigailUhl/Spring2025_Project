using Maui.eCommerceV3.ViewModels;
using Spring2025_Project.Models;

namespace Maui.eCommerceV3;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
    
    private void InventoryClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryManagement");
    }
    
    private void ShopClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShopManagement");
    }
    
}