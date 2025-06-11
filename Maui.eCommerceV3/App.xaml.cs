using Microsoft.Maui.Controls;

namespace Maui.eCommerceV3;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}