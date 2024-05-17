using CatalogueManagement.Interfaces;
using UnityEngine;

namespace PlayerManagement
{
    public class PlayerCoreManager : MonoBehaviour, IPlayerCoreManager
    {
        private static IPlayerCoreManager _mInstance;
        public static IPlayerCoreManager Instance => _mInstance;

        public IPlayerData PlayerData => _mPlayerData;


        private IPlayerData _mPlayerData;
        [SerializeField] private SpriteRenderer currentSword;

        private CharacterMovementController _mMovementController;
        
        private void Awake()
        {
            if (_mInstance == null)
            {
                _mInstance = this;
            }
            else if((PlayerCoreManager)_mInstance != this)
            {
                Destroy(this);
            }
            
            _mPlayerData = new PlayerData();
            _mMovementController = FindFirstObjectByType<CharacterMovementController>();
        }
        
        public void AddItem(IItemData newItem)
        {
            _mPlayerData.PlayerInventory.AddItemToInventory(newItem);
        }
    }

    public interface IPlayerCoreManager
    {
        public IPlayerData PlayerData { get; }
        public void AddItem(IItemData newItem);
    }
}