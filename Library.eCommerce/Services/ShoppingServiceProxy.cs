using Spring2025_Project.Models;
namespace Library.eCommerce.Services
{
    public class ShoppingServiceProxy
    {
        private ProductServiceProxy _prodSvc;
        private List<Item> items;
        public List<Item> CartItems
        {
            get { return items; }
        }
        public static ShoppingServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingServiceProxy();
                }
                return instance;
            }
        }
        private static ShoppingServiceProxy? instance;
        private ShoppingServiceProxy()
        {
            items = new List<Item?>();
        }
    }
}

