using CatalogueManagement.Interfaces;
using ShopManagement;
using UnityEngine;

namespace UI
{
    public interface IShopUIManagement : IItemSelectable
    {
        public void ToggleUI(bool isActive);
        public void SetShopData(IShopData visitedShop);
    }

    public interface IItemSelectable
    {
        public void SelectItem(IItemData itemData, Sprite imageSprite);
    }
}