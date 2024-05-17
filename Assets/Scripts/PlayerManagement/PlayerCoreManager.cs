using UnityEngine;

namespace PlayerManagement
{
    public class PlayerCoreManager : MonoBehaviour, IPlayerCoreManager
    {
        private static IPlayerCoreManager _mInstance;
        public static IPlayerCoreManager Instance => _mInstance;
        
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
        }
    }

    public interface IPlayerCoreManager
    {
    }
}