using UnityEngine;

namespace PlayerManagement
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class TopDownCharacterController : MonoBehaviour
    {
        private const float WalkSpeed = 3f;
        private const float RunSpeed = 6f;

        private Rigidbody2D _mRigidbody;
        private Animator _mAnimator;
        private Collider2D _mCollider;
        private SpriteRenderer _mSpriteRenderer;
        
        private Move _mMoveCommand;
        private void Awake()
        {
            _mMoveCommand = new Move();
            ConfirmRequiredComponents();
        }

        private void ConfirmRequiredComponents()
        {
            _mSpriteRenderer = GetComponent<SpriteRenderer>();
            _mRigidbody = GetComponent<Rigidbody2D>();
            _mAnimator = GetComponent<Animator>();
            _mCollider = GetComponent<CapsuleCollider2D>();
        }
        
        
        private void FixedUpdate()
        {
            ManageMovement();
        }
        private void ManageMovement()
        {
            var currentDir = Vector2.zero;
            currentDir.x = Input.GetKey(KeyCode.A) ? -1 : currentDir.x;
            currentDir.x = Input.GetKey(KeyCode.D) ? 1 : currentDir.x;
            currentDir.y = Input.GetKey(KeyCode.W) ? 1 : currentDir.y;
            currentDir.y = Input.GetKey(KeyCode.S) ? -1 : currentDir.y;
            
            currentDir.Normalize();
            var speed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
            _mMoveCommand.Execute(speed, currentDir, _mRigidbody);
        }
    }
}