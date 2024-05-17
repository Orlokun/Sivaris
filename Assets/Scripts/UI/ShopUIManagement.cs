using System.Collections.Generic;
using System.Linq;
using CatalogueManagement.Interfaces;
using PlayerManagement;
using ShopManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopUIManagement : MonoBehaviour, IShopUIManagement
    {
        private IShopData _mCurrentShop;

        [SerializeField] private GameObject mAvailableItemPrefab;
    
        [Header("Player")]
        [SerializeField] private Image mItemPreview;
        [SerializeField] private TMP_Text mPlayerCurrency;

        [Header("Shop Items")]
        [SerializeField] private Transform mAvailableItemsHolder;
        [SerializeField] private TMP_Text mItemDescription;
        [SerializeField] private TMP_Text mItemName;

        [Header("CanvasManagement")] 
        [SerializeField] private Button closeButton;
        [SerializeField] private Button purchaseButton;
        
        private Dictionary<int, GameObject> _mInstantiatedItems = new Dictionary<int, GameObject>();
        private IItemData _mCurrentSelectedItem;

        private void Awake()
        {
            closeButton.onClick.AddListener(Close);
            purchaseButton.onClick.AddListener(StartPurchaseProcess);
        }

        public void SetShopData(IShopData visitedShop)
        {
            _mCurrentShop = visitedShop;
            StartUpdateShopUI();
        }

        private void Close()
        {
            ToggleUI(false);
        }
        public void ToggleUI(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        /// <summary>
        /// Would use an Object pool for this but just a fast prototype
        /// </summary>
        private void StartUpdateShopUI()
        {
            ClearInstantiatedObjects();
            PopulateGameObjects();
            UpdateCurrency();
        }

        private void UpdateCurrency()
        {
            mPlayerCurrency.text = PlayerCoreManager.Instance.PlayerData.Currency.ToString();
        }


        private void ClearInstantiatedObjects()
        {
            foreach (var instantiatedItem in _mInstantiatedItems)
            {
                Destroy(instantiatedItem.Value);
            }
            _mInstantiatedItems.Clear();
        }
        
        private void PopulateGameObjects()
        {
            for(var i = 0;i<_mCurrentShop.AvailableItems.Count;i++)
            {
                var itemOverview = Instantiate(mAvailableItemPrefab, mAvailableItemsHolder);
                var itemController = itemOverview.GetComponent<ItemOverviewController>();
                itemController.InitializeData(this, _mCurrentShop.AvailableItems[i]);
                _mInstantiatedItems.Add(i, itemOverview);
            }
        }

        public void SelectItem(IItemData itemData, Sprite imageSprite)
        {
            mItemPreview.sprite = imageSprite;
            mItemPreview.color = Color.white;
            mItemDescription.text = itemData.Description;
            mItemName.text = itemData.Name;
            _mCurrentSelectedItem = itemData;
        }

        private void StartPurchaseProcess()
        {
            if (_mCurrentShop == null || _mCurrentSelectedItem == null)
            {
                Debug.Log("No item or shop selected");
                return;
            }
            if (_mCurrentShop.AvailableItems.All(x => x.Item.CodeId != _mCurrentSelectedItem.CodeId))
            {
                Debug.Log("Item is no available in current shop");
                return;
            }
            var availableItem = _mCurrentShop.AvailableItems.Single(x => x.Item.CodeId == _mCurrentSelectedItem.CodeId);
            if (availableItem.Quantity <= 0)
            {
                Debug.Log("Item is no longer available. SOLD");
                //Launch no more available dialogue.
                return;
            }

            var playerData = PlayerCoreManager.Instance.PlayerData;
            if (playerData.Currency < availableItem.Item.BuyPrice)
            {
                Debug.Log("YOU are too poor. Sorry");
                //Launch not enough money dialogue? 
                return;
            }

            if (playerData.PlayerInventory.InventoryItems.Any(x => x.CodeId == _mCurrentSelectedItem.CodeId))
            {
                Debug.Log("YOU already have this item. Leave some for the rest");
                return;
            }
            PurchaseItem(availableItem);
        }

        private void PurchaseItem(IShopItem availableItem)
        {
            _mCurrentShop.ReduceItemInStore(availableItem, 1);
            PlayerCoreManager.Instance.PlayerData.ReduceCurrency(availableItem.Item.BuyPrice);
            PlayerCoreManager.Instance.PlayerData.PlayerInventory.AddItemToInventory(availableItem.Item);
            UIManager.Instance.UpdateBaseUI();
            UpdateCurrency();
        }
    }
}