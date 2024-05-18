using PlayerManagement;
using UI;
using UnityEngine;

namespace ShopManagement.GenericShop
{
    public interface INpcShop
    {
        void LaunchFeedback(FeedbackType fbType);
    }

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class NpcShop : MonoBehaviour, INpcShop
    {
        protected IShopData ShopData; 
        [SerializeField] protected Animator _mAnim;
        [SerializeField] protected Collider2D _mCollider;
        
        protected virtual void Awake()
        {
            
        }
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsPlayer(other))
            {
                return;
            }
            Debug.Log("Player Entered Shop");
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (!IsPlayer(other))
            {
                return;
            }
            Debug.Log("Player Left Shop");
        }

        private bool IsPlayer(Collider2D col)
        {
            return col.TryGetComponent<CharacterMovementController>(out _);
        }
        
        public virtual void LaunchFeedback(FeedbackType fbType)
        {

        }
    }
}