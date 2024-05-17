using ShopManagement;

namespace UI
{
    public interface IShopUIManagement
    {
        public void ToggleUI(bool isActive);
        public void SetShopData(IShopData visitedShop);
    }
}