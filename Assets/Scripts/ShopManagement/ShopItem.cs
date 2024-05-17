using InventoryManagement;

namespace ShopManagement
{
    public class ShopItem : IShopItem
    {
        private IItemData _mItem;
        private int _mQuantity;

        public IItemData Item => _mItem;
        public int Quantity => _mQuantity;
        public ShopItem(IItemData item, int quantity)
        {
            _mItem = item;
            _mQuantity = quantity;
        }
    }
}