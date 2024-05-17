using System.Collections.Generic;
using ShopManagement;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
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

        [Header("Sprites")] 
        [SerializeField] private SpriteAtlas mSpriteAtlas;

        private Dictionary<int, GameObject> mInstantiatedItems = new Dictionary<int, GameObject>();

        public void SetShopData(IShopData visitedShop)
        {
            _mCurrentShop = visitedShop;
            StartUpdateShopUI();
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
        }

        private void ClearInstantiatedObjects()
        {
            foreach (var instantiatedItem in mInstantiatedItems)
            {
                Destroy(instantiatedItem.Value);
            }
            mInstantiatedItems.Clear();
        }
        
        private void PopulateGameObjects()
        {
            foreach (var shopItem in _mCurrentShop.AvailableItems)
            {
                var itemOverview = Instantiate(mAvailableItemPrefab, mAvailableItemsHolder);
                var itemController = itemOverview.GetComponent<ItemOverviewController>();
                itemController.InitializeData(shopItem);
            }
        }
    }
}