using PlayerManagement.Inventory;

namespace PlayerManagement
{
    public interface IPlayerData : IPlayerMoney
    {
        public IPlayerInventoryModule PlayerInventory { get; }
        public void ReduceCurrency(int charge);
        public void AddCurrency(int gained);
    }

    public interface IPlayerMoney
    {
        public int Currency { get; }
    }
}