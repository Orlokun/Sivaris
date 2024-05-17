using PlayerManagement.Inventory;

namespace PlayerManagement
{
    public class PlayerData : IPlayerData
    {
        private int _mCurrency = 100;
        public int Currency => _mCurrency;
        
        private const string Name = "Sivaris";
        public IPlayerInventoryModule PlayerInventory => _mInventory;
        public void ReduceCurrency(int charge)
        {
            _mCurrency -= charge;
        }

        private IPlayerInventoryModule _mInventory = new PlayerInventoryModule();
    }
}