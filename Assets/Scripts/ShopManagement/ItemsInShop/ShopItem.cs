using CatalogueManagement.Interfaces;

namespace ShopManagement.ItemsInShop
{
    public class ShopItem : IShopItem
    {
        private IItemData _mItemItem;
        private int _mQuantity;

        public IItemData Item => _mItemItem;
        public int Quantity => _mQuantity;
        public void Reduce(int quantity)
        {
            _mQuantity -= quantity;
            if (_mQuantity < 0)
            {
                _mQuantity = 0;
            }
        }

        public ShopItem(IItemData itemItem, int quantity)
        {
            _mItemItem = itemItem;
            _mQuantity = quantity;
        }
    }
}