using InventoryManagement;

namespace ShopManagement
{
    public interface IShopItem
    {
        public IItemData Item { get; }
        public int Quantity { get; }
    }
}