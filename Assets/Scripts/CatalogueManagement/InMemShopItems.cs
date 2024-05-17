using System.Collections.Generic;
using System.Linq;
using CatalogueManagement.Interfaces;
using ShopManagement;

namespace CatalogueManagement
{
    public static class InMemShopItems
    {
        public static List<IItemData> ExistingItems = new()
        {
            new ItemData(
                ItemCodeId.Liliths,
                "Lilith's Blade",
                "Swords 64x64 TRANSPARENT_38",
                "The sword carries the wisdom of old age wars and demons. Yield with caution, it could drain a weak soul in a swing",
                20,
                12
            ),            
            new ItemData(
                ItemCodeId.Durendal,
                "Durendal",
                "Swords 64x64 TRANSPARENT_11",
                "Dragon slayer sword.",
                20,
                12
            ),
            new ItemData(
                ItemCodeId.Longinus,
                "Sword of Longinus",
                "Swords 64x64 TRANSPARENT_1",
                "Though we couldn't find the spear, the sword ain't bad at all. Real good actually.",
                20,
                12
            ),
            new ItemData(
                ItemCodeId.Gram,
                "Gram",
                "Swords 64x64 TRANSPARENT_26",
                "Let's slay some monsters with this!",
                20,
                12
            ),
            new ItemData(
                ItemCodeId.Kusanagi,
                "Kusanagi",
                "Swords 64x64 TRANSPARENT_29",
                "No blade is as reliable as this one. A steel forged with honor.",
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