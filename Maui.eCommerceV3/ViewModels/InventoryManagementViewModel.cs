using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.eCommerce.Services;
using Library.eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring2025_Project.Models;

namespace Maui.eCommerceV3.ViewModels;

public class InventoryManagementViewModel : INotifyPropertyChanged
{
    public Item? SelectedProduct { get; set; }
    public string? Query { get; set; }
    private ProductServiceProxy _svc = ProductServiceProxy.Current;
    public event PropertyChangedEventHandler? PropertyChanged;
    public string SortOption { get; set; } = null; 

    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (propertyName is null)
        {
            throw new ArgumentNullException(nameof(propertyName));
        }
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RefreshProductList()
    {
        NotifyPropertyChanged(nameof(Products));
    }
    
    public ObservableCollection<Item?> Products
    {
        get
        {
            var filteredList = _svc.Products.Where(p => p?.Product?.Name?.ToLower().Contains(Query?.ToLower() ?? string.Empty) ?? false);
            IEnumerable<Item?> sortedList = filteredList;
            if (!string.IsNullOrEmpty(SortOption))
            {
                sortedList = SortOption switch
                {
                    "Price: Low to High" => filteredList.OrderBy(p => p?.Product?.Price),
                    "Price: High to Low" => filteredList.OrderByDescending(p => p?.Product?.Price),
                    "Alphabetical (A-Z)" => filteredList.OrderBy(p => p?.Product?.Name),
                    _ => filteredList
                };
            }
            return new ObservableCollection<Item?>(sortedList);
        }
    }

    public Item? Delete()
    {
        var item = _svc.Delete(SelectedProduct?.Id ?? 0);
        NotifyPropertyChanged("Products");
        return item;
    }
}