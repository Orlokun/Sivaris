using DialogueManager;
using ShopManagement;
using ShopManagement.GenericShop;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private static IUIManager _mInstance;
        public static IUIManager Instance => _mInstance;

        [SerializeField] private ShopUIManagement mShopManager;
        [SerializeField] private DialogueOperator mDialogueManager;
        [SerializeField] private BaseInfoCanvas mInfoCanvas;
        public IShopUIManagement ShopUIManager => mShopManager;
        public IDialogueOperator DialogueManager => mDialogueManager;
        public IBaseInfoCanvas InfoCanvas => mInfoCanvas;
        
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
            ToggleShopUI(false);
            ToggleDialogueUI(false);
        }

        private void Start()
        {
            ToggleShopUI(false);
            ToggleDialogueUI(false);
        }

        public void SetCurrentShop(IShopData shopData, NpcShop undertakerNpc)
        {
            ShopUIManager.SetShopData(shopData, undertakerNpc);
        }

        public void ToggleShopUI(bool isActive)
        {
            ShopUIManager.ToggleUI(isActive);
        }

        public void ToggleDialogueUI(bool isActive)
        {
            DialogueManager.ToggleUI(isActive);
        }

        public void UpdateBaseUI()
        {
            mInfoCanvas.UpdateMoneyText();
        }
    }

    public interface IUIManager
    {
        public void SetCurrentShop(IShopData shopData, NpcShop undertakerNpc);
        public void ToggleShopUI(bool isActive);
        void UpdateBaseUI();
        public void ToggleDialogueUI(bool isActive);

        public IDialogueOperator DialogueManager { get; }
    }
}