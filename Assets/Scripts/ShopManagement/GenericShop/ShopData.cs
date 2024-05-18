using System.Collections.Generic;
using System.Linq;
using ShopManagement.ItemsInShop;

namespace ShopManagement.GenericShop
{
    public class ShopData : IShopData
    {
        public string NpcName => _mNpcName;
        private string _mNpcName;

        private List<IShopItem> _mShopItems;
        public List<IShopItem> AvailableItems => _mShopItems;
        public void ReduceItemInStore(IShopItem shopItem, int quantity)
        {
            var shoppedItem = AvailableItems.Single(x => x.Item.CodeId == shopItem.Item.CodeId);
            shoppedItem.Reduce(quantity);
        }

        public ShopData(string mNpcName, List<IShopItem> items)
        {
            _mNpcName = mNpcName;
            _mShopItems = items;
        }
    }
}