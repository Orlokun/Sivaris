using System;

namespace InventoryManagement
{
    public class ItemData : IItemData
    {
        private Guid _mId;
        private string _mName;
        private string _mIconPath;
        private string _mDescription;
        private int _mBuyPrice;
        private int _mSellPrice;

        public Guid Id => _mId;
        public string Name => _mName;
        public string IconPath => _mIconPath;
        public string Description => _mDescription;
        public int BuyPrice => _mBuyPrice;
        public int SellPrice => _mSellPrice;
        
        public ItemData(string mName, string mIconPath, string mDescription, int mBuyPrice, int mSellPrice)
        {
            _mId = Guid.NewGuid();
            _mName = mName;
            _mIconPath = mIconPath;
            _mDescription = mDescription;
            _mBuyPrice = mBuyPrice;
            _mSellPrice = mSellPrice;
        }
    }

    public interface IExchangeable
    {
        public int BuyPrice { get; }
        public int SellPrice { get; }
    }
    public interface IItemData : IExchangeable, IBaseData
    {
        public string IconPath { get; }
        public string Description { get; }
    }

    public enum ItemId
    {
        Liliths,
        Durendal,
        Longinus,
        Gram,
        Kusanagi
    }
    
    public interface IBaseData
    {
        public Guid Id { get; }
        public string Name { get; }
    }
}