using Spring2025_Project.Models;
using Library.eCommerce.Services;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Amazon!");
            Console.WriteLine("C. Create new inventory item");
            Console.WriteLine("R. Read all inventory items");
            Console.WriteLine("U. Update an inventory item");
            Console.WriteLine("D. Delete an inventory item");
            Console.WriteLine("A. Add item to shopping cart");
            Console.WriteLine("V. View shopping cart");
            Console.WriteLine("T. Throw away item from shopping cart");
            Console.WriteLine("Q. Quit and checkout");

            List<Product?> list = ProductServiceProxy.Current.Products;
            ShoppingServiceProxy cartService = ShoppingServiceProxy.Current;
            
            char choice;
            do
            {
                string? input = Console.ReadLine();
                choice = input[0];
                switch (choice)
                {
                    case 'C':
                    case 'c':
                        ProductServiceProxy.Current.AddorUpdate(new Product
                        {
                            Name = Console.ReadLine()
                        });
                        break;
                    case 'R':
                    case 'r':
                        list.ForEach(Console.WriteLine);
                        break;
                    case 'U':
                    case 'u':
                        Console.WriteLine("Which product would you like to update?");
                        int selection = int.Parse(Console.ReadLine() ?? "-1");
                        var selectedProd = list.FirstOrDefault(p => p.Id == selection);
                        
                        if (selectedProd != null)
                        {
                            selectedProd.Name = Console.ReadLine() ?? "ERROR";
                            ProductServiceProxy.Current.AddorUpdate(selectedProd);
                        }
                        break;
                    case 'D':
                    case 'd':
                        Console.WriteLine("Which product would you like to delete?");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        ProductServiceProxy.Current.Delete(selection);
                        break;
                    case 'A':
                    case 'a':
                        Console.WriteLine("Which product would you like to add to cart?");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        cartService.AddToCart(selection);
                        break;
                    case 'V':
                    case 'v':
                        Console.WriteLine("Shopping Cart:");
                        cartService.ShoppingCart.ForEach(Console.WriteLine);
                        break;
                    case 'T':
                    case 't':
                        Console.WriteLine("What product would you like to remove from cart?");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        cartService.RemoveFromCart(selection);
                        break;
                    case 'Q':
                    case 'q':
                        cartService.Checkout();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (choice != 'Q' && choice != 'q');

            Console.ReadLine();
        }
    }
}