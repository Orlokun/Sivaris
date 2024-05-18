using CatalogueManagement.Interfaces;
using ShopManagement;
using ShopManagement.GenericShop;
using UnityEngine;

namespace UI
{
    public interface IShopUIManagement : IItemSelectable
    {
        public void ToggleUI(bool isActive);
        public void SetShopData(IShopData visitedShop, NpcShop shopOwner);
        public void UpdateShopUI();
    }

    public interface IItemSelectable
    {
        public void SelectItem(IItemData itemData, Sprite imageSprite);
    }
}