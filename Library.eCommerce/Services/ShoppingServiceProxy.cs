using Spring2025_Project.Models;
namespace Library.eCommerce.Services
{
    public class ShoppingServiceProxy
    {
        private ShoppingServiceProxy()
        {
            ShoppingCart = new List<Product?>();
        }
        
        private static ShoppingServiceProxy? instance;
        private static object instanceLock = new object();
        
        public static ShoppingServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShoppingServiceProxy();
                    }
                }
                return instance;
            }
        }
        public List<Product?> ShoppingCart { get; private set; }
        
        public Product AddToCart(int productId)
        {
            var product = ProductServiceProxy.Current.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                ShoppingCart.Add(product);
                ProductServiceProxy.Current.Delete(productId);
            }
            return product;
        }
        
        public Product RemoveFromCart(int productId)
        {
            var product = ShoppingCart.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                ShoppingCart.Remove(product);
                ProductServiceProxy.Current.AddOrUpdate(product);
            }
            return product;
        }
        
        public void Checkout()
        {
            Console.WriteLine("\n--- Receipt ---");
            double total = 0;
            foreach (var product in ShoppingCart)
            {
                Console.WriteLine(product);
                total += 10;
            }
            double tax = total * 0.07;
            Console.WriteLine($"Subtotal: ${total:F2}");
            Console.WriteLine($"Tax (7%): ${tax:F2}");
            Console.WriteLine($"Total: ${(total + tax):F2}");
            ShoppingCart.Clear();
        }
    }
}

