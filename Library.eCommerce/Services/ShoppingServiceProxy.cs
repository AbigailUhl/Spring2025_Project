using Spring2025_Project.Models;
using Library.eCommerce.Models;

namespace Library.eCommerce.Services
{
    public class ShoppingServiceProxy
    {
        private ProductServiceProxy _prodSvc = ProductServiceProxy.Current;
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
            items = new List<Item>();
        }

        public Item? AddOrUpdate(Item item)
        {
            var existingInvItem = _prodSvc.GetById(item.Id);
            if (existingInvItem == null || existingInvItem.Quantity == 0)
            {
                return null;
            }
            if (existingInvItem != null)
            {
                existingInvItem.Quantity--;
            }
            var existingItem = CartItems.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem == null)
            {
                var newItem = new Item(item);
                newItem.Quantity = 1;
                CartItems.Add(newItem);
            }
            else
            {
                existingItem.Quantity++;
            }
            return existingInvItem;
        }
        
        public Item? ReturnItem(Item? item)
        {
            if (item?.Id <= 0 || item == null)
            {
                return null;
            }
            var itemToReturn = CartItems.FirstOrDefault(c => c.Id == item.Id);
            if (itemToReturn != null)
            {
                itemToReturn.Quantity --;
                var inventoryItem = _prodSvc.Products.FirstOrDefault(p => p.Id == itemToReturn.Id);
                if (inventoryItem == null)
                {
                    _prodSvc.AddOrUpdate(new Item(itemToReturn));
                }
                else
                {
                    inventoryItem.Quantity++;
                }
            }
            return itemToReturn;
        }
    }
}