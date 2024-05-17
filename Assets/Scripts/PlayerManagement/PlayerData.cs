using System.Collections.Generic;
using CatalogueManagement.Interfaces;

namespace PlayerManagement
{
    public class PlayerData : IPlayerData
    {
        private int _mCurrency = 2;
        private string Name = "Sivaris";
        private List<IItemData> PlayerItems;
        public int Currency => _mCurrency;
    }
}