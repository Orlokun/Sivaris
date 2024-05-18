using System.Collections.Generic;
using CatalogueManagement.Interfaces;
using DialogueManager;
using UI;
using UnityEngine;

namespace PlayerManagement
{
    public class PlayerCoreManager : MonoBehaviour, IPlayerCoreManager
    {
        private Dictionary<FindEventId, bool> SmallGameEvents = new()
        {
            { FindEventId.Tomb1, false },
            { FindEventId.Tomb2, false },
            { FindEventId.Tomb3, false },
            { FindEventId.Tomb4, false },
        };

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
            else if ((PlayerCoreManager)_mInstance != this)
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
        public void SetNewSword(Sprite newSword)
        {
            currentSword.sprite = newSword;
            currentSword.color = Color.white;
        }
        
        
        private bool _mIsEventActive = false;
        private FindEventId _mTombEventAvailable;
        public void PlayerSwitchTombState(bool isEventActive, FindEventId tombEventId)
        {
            _mIsEventActive = isEventActive;
            _mTombEventAvailable = tombEventId;
        }

        private void Update()
        {
            if (!_mIsEventActive)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!SmallGameEvents[_mTombEventAvailable])
                {
                    StartDialogue();
                }
            }
        }

        private void StartDialogue()
        {
            UIManager.Instance.DialogueManager.ToggleUI(true);
            var getDialogue = InMemTombDialogues.UnlockedTomb[(int)_mTombEventAvailable];
            UIManager.Instance.DialogueManager.StartNewDialogue(getDialogue);
            UIManager.Instance.DialogueManager.OnDialogueCompleted += LaunchEvent;
        }

        private void LaunchEvent()
        {
            SmallGameEvents[_mTombEventAvailable] = true;
            _mPlayerData.AddCurrency(5);
            PlayerSwitchTombState(false, 0);
            UIManager.Instance.DialogueManager.OnDialogueCompleted -= LaunchEvent;
        }
    }

    public interface IPlayerCoreManager
    {
        public void SetNewSword(Sprite newSword);
        public IPlayerData PlayerData { get; }
        public void AddItem(IItemData newItem);

        public void PlayerSwitchTombState(bool isEventActive, FindEventId tombEventId);
    }
}