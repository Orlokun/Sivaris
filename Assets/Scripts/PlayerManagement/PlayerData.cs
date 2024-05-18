using PlayerManagement.Inventory;
using UI;

namespace PlayerManagement
{
    public class PlayerData : IPlayerData
    {
        private int _mCurrency = 2;
        public int Currency => _mCurrency;
        
        private const string Name = "Sivaris";
        public IPlayerInventoryModule PlayerInventory => _mInventory;
        public void ReduceCurrency(int charge)
        {
            _mCurrency -= charge;
            _mCurrency = _mCurrency < 0 ? 0 : _mCurrency;
            UIManager.Instance.UpdateBaseUI();
        }
        public void AddCurrency(int gained)
        {
            _mCurrency += gained;
            UIManager.Instance.UpdateBaseUI();
        }

        private IPlayerInventoryModule _mInventory = new PlayerInventoryModule();
    }
}