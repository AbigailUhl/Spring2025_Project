using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerceV3.Views;

public partial class ShopManagementView : ContentPage
{
    public ShopManagementView()
    {
        InitializeComponent();
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}