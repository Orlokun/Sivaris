using System.Collections.Generic;

namespace InventoryManagement
{
    public static class InMemShopItems
    {
        public static List<IItemData> ExistingItems = new()
        {
            new ItemData(
                "Lilith's Blade",
                "SwordsAtlas[Swords 64x64 TRANSPARENT_38]",
                "The best sword around town",
                20,
                12
            ),            
            new ItemData(
                "Durendal",
                "SwordsAtlas[Swords 64x64 TRANSPARENT_11]",
                "The best sword around town",
                20,
                12
            ),
            new ItemData(
                "Sword of Longinus",
                "SwordsAtlas[Swords 64x64 TRANSPARENT_1]",
                "The best sword around town",
                20,
                12
            ),
            new ItemData(
                "Gram",
                "SwordsAtlas[Swords 64x64 TRANSPARENT_26]",
                "The best sword around town",
                20,
                12
            ),
            new ItemData(
                "Kusanagi",
                "SwordsAtlas[Swords 64x64 TRANSPARENT_29]",
                "The best sword around town",
                20,
                12
            ),
        };
    }
}