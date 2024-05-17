using System.Collections.Generic;
using System.Linq;
using ShopManagement;

namespace InventoryManagement
{
    public static class InMemShopItems
    {
        public static List<IItemData> ExistingItems = new()
        {
            new ItemData(
                ItemCodeId.Liliths,
                "Lilith's Blade",
                "Swords 64x64 TRANSPARENT_38",
                "The best sword around town",
                20,
                12
            ),            
            new ItemData(
                ItemCodeId.Durendal,
                "Durendal",
                "Swords 64x64 TRANSPARENT_11",
                "The best sword around town",
                20,
                12
            ),
            new ItemData(
                ItemCodeId.Longinus,
                "Sword of Longinus",
                "Swords 64x64 TRANSPARENT_1",
                "The best sword around town",
                20,
                12
            ),
            new ItemData(
                ItemCodeId.Gram,
                "Gram",
                "Swords 64x64 TRANSPARENT_26",
                "The best sword around town",
                20,
                12
            ),
            new ItemData(
                ItemCodeId.Kusanagi,
                "Kusanagi",
                "Swords 64x64 TRANSPARENT_29",
                "The best sword around town",
                20,
                12
            ),
        };

        /// <summary>
        /// Hard Coded quantity of items. Should be flexible.
        /// </summary>
        /// <param name="requiredItems"></param>
        /// <returns></returns>
        public static List<IShopItem> GetItemsShopData(List<ItemCodeId> requiredItems)
        {
            var resultItems = new List<IShopItem>();
            foreach (var requiredItem in requiredItems)
            {
                if (ExistingItems.All(x => x.CodeId != requiredItem))
                {
                    continue;
                }
                var item = ExistingItems.Single(x => x.CodeId == requiredItem);
                var itemShopData = new ShopItem(item, 1);
                resultItems.Add(itemShopData);
            }
            return resultItems;
        }
    }
}