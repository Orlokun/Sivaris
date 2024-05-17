using System.Collections.Generic;
using CatalogueManagement;
using UI;
using UnityEngine;

namespace ShopManagement
{
    public class UndertakerNpc : NpcShop
    {
        private List<ItemCodeId> RequiredItems = new List<ItemCodeId>()
        {
            ItemCodeId.Durendal,
            ItemCodeId.Gram,
            ItemCodeId.Kusanagi,
            ItemCodeId.Liliths,
            ItemCodeId.Longinus
        };
        
        
        protected override void Awake()
        {
            var items = InMemShopItems.GetItemsShopData(RequiredItems);
            ShopData = new ShopData("Silvia", items);
        }
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            UIManager.Instance.SetCurrentShop(ShopData);
            UIManager.Instance.ToggleShopUI(true);
        }
        protected override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            UIManager.Instance.ToggleShopUI(false);
        }


    }
}