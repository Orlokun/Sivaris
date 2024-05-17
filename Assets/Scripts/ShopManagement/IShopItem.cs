using CatalogueManagement.Interfaces;

namespace ShopManagement
{
    public interface IShopItem
    {
        public IItemData Item { get; }
        public int Quantity { get; }
        public void Reduce(int quantity);
    }
}