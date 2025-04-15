using Library.eCommerce.Models;
using Library.eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerceV3.ViewModels;

public class ShopManagementViewModel
{
    private ProductServiceProxy _invSvc = ProductServiceProxy.Current;

    public ObservableCollection<Item?> Inventory
    {
        get
        {
            return new ObservableCollection<Item?>(_invSvc.Products);
        }
    }
}