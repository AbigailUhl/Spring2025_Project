using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerceV3.Views;

public partial class TaxConfigView : ContentPage
{
    public TaxConfigView()
    {
        InitializeComponent();
        TaxEntry.Text = Preferences.Default.Get("SalesTaxRate", 7.0).ToString("F2");
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        if (double.TryParse(TaxEntry.Text, out double taxRate))
        {
            Preferences.Default.Set("SalesTaxRate", taxRate);
            DisplayAlert("Saved", $"Tax rate set to {taxRate:F2}%", "OK");
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid tax rate.", "OK");
        }
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}