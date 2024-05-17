using System.Collections.Generic;
using System.Linq;
using CatalogueManagement;
using CatalogueManagement.Interfaces;

namespace PlayerManagement.Inventory
{
    public class PlayerInventoryModule : IPlayerInventoryModule
    {
        public List<IItemData> InventoryItems => _mInventoryItems;
        private List<IItemData> _mInventoryItems = new();

        public void AddItemToInventory(IItemData newItem)
        {
            if (InventoryItems.Any(x => x.CodeId == newItem.CodeId))
            {
                return;
            }
            _mInventoryItems.Add(newItem);
        }
    }

    public interface IPlayerInventoryModule
    {
        public List<IItemData> InventoryItems { get; }
        public void AddItemToInventory(IItemData newItem);
    }
}