using PlayerManagement;
using UnityEngine;

namespace ShopManagement
{
    
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class NpcShop : MonoBehaviour
    {
        [SerializeField] private Animator _mAnim;
        [SerializeField] private Collider2D _mCollider;
        
        private void Awake()
        {
            
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsPlayer(other))
            {
                return;
            }
            Debug.Log("Player Entered Shop");
        }

        protected void OnTriggerExit2D(Collider2D other)
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
    }
}