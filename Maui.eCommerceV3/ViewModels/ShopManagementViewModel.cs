using Library.eCommerce.Models;
using Library.eCommerce.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Maui.eCommerceV3.ViewModels;

public class ShopManagementViewModel : INotifyPropertyChanged
{
    private ProductServiceProxy _invSvc = ProductServiceProxy.Current;
    private ShoppingServiceProxy _cartSvc = ShoppingServiceProxy.Current;
    public Item? SelectedItem { get; set; }
    public Item? SelectedCartItem { get; set; }
    public string SortOption { get; set; } = null; 
    public ObservableCollection<Item?> Inventory
    {
        get
        {
            var filtered = _invSvc.Products.Where(i => i?.Quantity > 0);
            IEnumerable<Item?> sorted = filtered;

            if (!string.IsNullOrEmpty(SortOption))
            {
                sorted = SortOption switch
                {
                    "Price: Low to High" => filtered.OrderBy(i => i?.Product?.Price),
                    "Price: High to Low" => filtered.OrderByDescending(i => i?.Product?.Price),
                    "Alphabetical (A-Z)" => filtered.OrderBy(i => i?.Product?.Name),
                    _ => filtered
                };
            }
            return new ObservableCollection<Item?>(sorted);
        }
    }
    public ObservableCollection<Item?> ShoppingCart
    {
        get
        {
            var filtered = _cartSvc.CartItems.Where(i => i?.Quantity > 0);
            return new ObservableCollection<Item?>(filtered);
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (propertyName is null)
        {
            throw new ArgumentNullException(nameof(propertyName));
        }
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public void RefreshUX()
    {
        NotifyPropertyChanged(nameof(Inventory));
        NotifyPropertyChanged(nameof(ShoppingCart));
    }
    
    public void PurchaseItem()
    {
        if (SelectedItem != null)
        {
            if (SelectedItem.InlineQuantity <= 0)
                SelectedItem.InlineQuantity = 1;

            for (int i = 0; i < SelectedItem.InlineQuantity; i++)
            {
                _cartSvc.AddOrUpdate(SelectedItem);
            }

            NotifyPropertyChanged(nameof(Inventory));
            NotifyPropertyChanged(nameof(ShoppingCart));
        }
    }

    public void ReturnItem()
    {
        if (SelectedCartItem != null)
        {
            var shouldRefresh= SelectedCartItem.Quantity >= 1;
            var updatedItem = _cartSvc.ReturnItem(SelectedCartItem);
            if (updatedItem != null && shouldRefresh)
            {
                NotifyPropertyChanged(nameof(Inventory));
                NotifyPropertyChanged(nameof(ShoppingCart));
            }
        }
    }
}