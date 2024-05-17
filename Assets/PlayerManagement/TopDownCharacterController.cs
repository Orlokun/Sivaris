using System.Collections.Generic;
using System.Linq;
using PlayerManagement.Commands;
using UnityEngine;

namespace PlayerManagement
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class TopDownCharacterController : MonoBehaviour
    {
        #region InMemData

        private static Dictionary<BaseMovementAnimations, string> BasePlayerAnim => new()
        {
            { BaseMovementAnimations.IdleUp , "Idle_Up"},
            { BaseMovementAnimations.IdleDown , "Idle_Down"},
            { BaseMovementAnimations.IdleLeft , "Idle_Left"},
            { BaseMovementAnimations.IdleRight , "Idle_Right"},
            { BaseMovementAnimations.WalkUp , "Walk_Up"},
            { BaseMovementAnimations.WalkDown , "Walk_Down"},
            { BaseMovementAnimations.WalkLeft , "Walk_Left"},
            { BaseMovementAnimations.WalkRight , "Walk_Right"},
        };
        #endregion

        private Vector2 _mCurrentDirection = Vector2.zero;
        private const float WalkSpeed = 3f;
        private const float RunSpeed = 6f;

        private Rigidbody2D _mRigidbody;
        private Animator _mAnimator;
        private Collider2D _mCollider;
        private SpriteRenderer _mSpriteRenderer;
        
        private IMoveCommand _mMoveCommand;
        private IAnimatedObject _mAnimatorData;
        private void Awake()
        {
            ConfirmRequiredComponents();
            _mMoveCommand = new CharacterMoveCommand();
            _mAnimatorData = new AnimatedObject(_mAnimator, BasePlayerAnim);
        }

        private void ConfirmRequiredComponents()
        {
            _mSpriteRenderer = GetComponent<SpriteRenderer>();
            _mRigidbody = GetComponent<Rigidbody2D>();
            _mAnimator = GetComponent<Animator>();
            _mCollider = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            ManageMovementInput();
            //Manage Movement animation
            _mMoveCommand.Execute(_mCurrentDirection, _mAnimatorData, transform);
        }
        private void ManageMovementInput()
        {
            _mCurrentDirection = Vector2.zero;
            _mCurrentDirection.x = Input.GetKey(KeyCode.A) ? -1 : _mCurrentDirection.x;
            _mCurrentDirection.x = Input.GetKey(KeyCode.D) ? 1 : _mCurrentDirection.x;
            _mCurrentDirection.y = Input.GetKey(KeyCode.W) ? 1 : _mCurrentDirection.y;
            _mCurrentDirection.y = Input.GetKey(KeyCode.S) ? -1 : _mCurrentDirection.y;
        }
        private void FixedUpdate()
        {
            ManageMovement();
        }
        private void ManageMovement()
        {
            _mCurrentDirection.Normalize();
            var speed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
            _mMoveCommand.Execute(speed, _mCurrentDirection, _mRigidbody);
        }
    }
}