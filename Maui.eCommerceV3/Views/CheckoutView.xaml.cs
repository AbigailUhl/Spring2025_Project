using Microsoft.Maui.Controls;
using Maui.eCommerceV3.ViewModels;
using Spring2025_Project.Models;
using System.Text;

namespace Maui.eCommerceV3.Views
{
    public partial class CheckoutView : ContentPage
    {
        public CheckoutView()
        {
            InitializeComponent();
            GenerateReceipt();
        }

        private void GenerateReceipt()
        {
            var cart = new ShopManagementViewModel().ShoppingCart;
            var taxRate = Preferences.Default.Get("SalesTaxRate", 7.0) / 100;

            double subtotal = 0;
            string items = "";

            foreach (var item in cart)
            {
                if (item?.Product == null || item.Quantity == null) continue;

                var price = item.Product.Price;
                var qty = item.Quantity.Value;
                var total = price * qty;

                subtotal += (double)total;
                items += $"{item.Product.Name} x {qty} - ${total:F2}\n";
            }

            double tax = subtotal * taxRate;
            double final = subtotal + tax;

            ItemListLabel.Text = items;
            SubtotalLabel.Text = $"Subtotal: ${subtotal:F2}";
            TaxLabel.Text = $"Tax: ${tax:F2}";
            TotalLabel.Text = $"Total: ${final:F2}";
        }
        private void GoBackClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ShopManagement");
        }
    }
}