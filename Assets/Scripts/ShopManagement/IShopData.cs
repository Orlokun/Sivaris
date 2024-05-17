using System.Collections.Generic;

namespace ShopManagement
{
    public interface IShopData
    {
        public string NpcName { get; }
        public List<IShopItem> AvailableItems { get; }
        public void ReduceItemInStore(IShopItem shoppedItem, int quantity);
    }
}