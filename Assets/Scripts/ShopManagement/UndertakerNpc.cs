using System;
using System.Collections.Generic;
using CatalogueManagement;
using PlayerManagement;
using ShopManagement.GenericShop;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

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
            if (PlayerCoreManager.Instance.PlayerData.Currency > 20)
            {
                Random.InitState(DateTime.Now.Millisecond);
                var randomDialogue = Random.Range(0, UndertakerInMemDialogues.WelcomeDialogues.Count);
                UIManager.Instance.DialogueManager.OnDialogueCompleted += OpenShop;
                UIManager.Instance.DialogueManager.StartNewDialogue(UndertakerInMemDialogues.WelcomeDialogues[randomDialogue]);
            }
            else
            {
                Random.InitState(DateTime.Now.Millisecond);
                var randomDialogue = Random.Range(0, UndertakerInMemDialogues.RejectionDialogues.Count);
                UIManager.Instance.DialogueManager.StartNewDialogue(UndertakerInMemDialogues.RejectionDialogues[randomDialogue]);
            }
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            UIManager.Instance.ToggleShopUI(false);
        }

        private void OpenShop()
        {
            UIManager.Instance.SetCurrentShop(ShopData);
            UIManager.Instance.ToggleShopUI(true);
            UIManager.Instance.DialogueManager.OnDialogueCompleted -= OpenShop;
        }
    }
}