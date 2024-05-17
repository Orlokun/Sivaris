using System.Collections.Generic;

namespace ShopManagement
{
    public class ShopData : IShopData
    {
        public string NpcName => _mNpcName;
        private string _mNpcName;

        private List<IShopItem> _mShopItems;
        public List<IShopItem> AvailableItems => _mShopItems;

        public ShopData(string mNpcName, List<IShopItem> items)
        {
            _mNpcName = mNpcName;
            _mShopItems = items;
        }
    }
}