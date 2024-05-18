using CatalogueManagement.Interfaces;

namespace ShopManagement.ItemsInShop
{
    public interface IShopItem
    {
        public IItemData Item { get; }
        public int Quantity { get; }
        public void Reduce(int quantity);
    }
}