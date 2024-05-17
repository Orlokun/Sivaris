using ShopManagement;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private static IUIManager _mInstance;
        public static IUIManager Instance => _mInstance;

        [SerializeField] private ShopUIManagement mShopManager;
        public IShopUIManagement ShopUIManager => mShopManager;
        
        private void Awake()
        {
            if (_mInstance == null)
            {
                _mInstance = this;
            }
            else if((UIManager)_mInstance != this)
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            ToggleShopUI(false);
        }

        public void SetCurrentShop(IShopData shopData)
        {
            ShopUIManager.SetShopData(shopData);
        }

        public void ToggleShopUI(bool isActive)
        {
            ShopUIManager.ToggleUI(isActive);
        }
    }

    public interface IUIManager
    {
        public void SetCurrentShop(IShopData shopData);
        public void ToggleShopUI(bool isActive);
    }
}