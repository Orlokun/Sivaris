using CatalogueManagement.Interfaces;

namespace ShopManagement
{
    public class ShopItem : IShopItem
    {
        private IItemData _mItemItem;
        private int _mQuantity;

        public IItemData Item => _mItemItem;
        public int Quantity => _mQuantity;
        public ShopItem(IItemData itemItem, int quantity)
        {
            _mItemItem = itemItem;
            _mQuantity = quantity;
        }
    }
}