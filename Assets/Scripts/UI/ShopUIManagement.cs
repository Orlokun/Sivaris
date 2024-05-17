using System.Collections.Generic;
using ShopManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopUIManagement : MonoBehaviour, IShopUIManagement
    {
        private IShopData _mCurrentShop;

        [SerializeField] private GameObject _mAvailableItemPrefab;
    
        [Header("Player")]
        [SerializeField] private Image _mItemPreview;
        [SerializeField] private TMP_Text _mPlayerCurrency;

        [Header("Shop Items")]
        [SerializeField] private Transform _mAvailableItemsHolder;
        [SerializeField] private TMP_Text _mItemDescription;

        private Dictionary<int, GameObject> _mInstantiatedItems = new Dictionary<int, GameObject>();

        public void SetShop(IShopData visitedShop)
        {
            _mCurrentShop = visitedShop;
            StartUpdateShopUI();
        }
    
        private void StartUpdateShopUI()
        {
            ClearInstantiatedObjects();
        }

        /// <summary>
        /// Would use an Object pool for this but just a fast prototype
        /// </summary>
        private void ClearInstantiatedObjects()
        {
            foreach (var instantiatedItem in _mInstantiatedItems)
            {
                Destroy(instantiatedItem.Value);
            }
            _mInstantiatedItems.Clear();
        }

        private void ClearObjects()
        {
            //New Comment      
        }

        public void ToggleUI(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }

    public interface IShopUIManagement
    {
        public void ToggleUI(bool isActive);
    }
}