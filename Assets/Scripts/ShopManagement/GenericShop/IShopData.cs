using System.Collections.Generic;
using ShopManagement.ItemsInShop;
using UI;

namespace ShopManagement.GenericShop
{
    public interface IShopData
    {
        public string NpcName { get; }
        public List<IShopItem> AvailableItems { get; }
        public void ReduceItemInStore(IShopItem shoppedItem, int quantity);
    }
}