using PlayerManagement;
using UnityEngine;

namespace Commands
{
    public class CharacterMoveCommand : IMoveCommand
    {
        private Vector2 _mCurrentMovement;
        
        //Resolve simple physics animation
        public void Execute(float speed, Vector2 direction, Rigidbody2D rBody)
        {
            rBody.velocity = speed * direction;
        }
        
        //Resolve Movement Animation
        public void Execute(Vector2 direction, IAnimatedObject animatedObject)
        {
            if (!HasStatusChange(direction))
            {
                //No status change. Return
                return;
            }
            //If player stopped moving. Set anim to idle state
            if (direction == Vector2.zero)
            {
                ResolveNewIdleState(animatedObject);
                _mCurrentMovement = direction;
                return;
            }
            
            //If player started moving sideways
            if (direction.x != 0 && direction.x != _mCurrentMovement.x)
            {
                var walkAnim = direction.x > 0 ? BaseMovementAnimations.WalkRight : BaseMovementAnimations.WalkLeft;
                animatedObject.ChangeAnimationState(walkAnim);
                _mCurrentMovement = direction;
                return;
            }

            //Player stopped moving to a side but is still moving
            if (direction.x == 0 && direction.x != _mCurrentMovement.x)
            {
                var walkAnim = direction.y > 0 ? BaseMovementAnimations.WalkUp : BaseMovementAnimations.WalkDown;
                animatedObject.ChangeAnimationState(walkAnim);
                _mCurrentMovement = direction;
                return;
            }
            
            //Player started moving up or down
            if (direction.y != 0 && direction.y != _mCurrentMovement.y)
            {
                var animState = direction.y > 0 ? BaseMovementAnimations.WalkUp: BaseMovementAnimations.WalkDown;
                animatedObject.ChangeAnimationState(animState);
                _mCurrentMovement = direction;
                return;
            }
            
            //Player stopped moving to top/down but is still moving left/right
            if (direction.y == 0 && direction.y != _mCurrentMovement.y)
            {
                var animState = direction.x > 0 ? BaseMovementAnimations.WalkRight: BaseMovementAnimations.WalkLeft;
                animatedObject.ChangeAnimationState(animState);
                _mCurrentMovement = direction;
            }
        }

        #region Utils
        private void ResolveNewIdleState(IAnimatedObject animatedObject)
        {
            var currentAnim = animatedObject.GetCurrentAnim();
            switch (currentAnim)
            {
                case BaseMovementAnimations.WalkDown:
                    animatedObject.ChangeAnimationState(BaseMovementAnimations.IdleDown);
                    break;                
                case BaseMovementAnimations.WalkLeft:
                    animatedObject.ChangeAnimationState(BaseMovementAnimations.IdleLeft);
                    break;                 
                case BaseMovementAnimations.WalkRight:
                    animatedObject.ChangeAnimationState(BaseMovementAnimations.IdleRight);
                    break;                
                case BaseMovementAnimations.WalkUp:
                    animatedObject.ChangeAnimationState(BaseMovementAnimations.IdleUp);
                    break;
            }
        }
        private bool HasStatusChange(Vector2 direction)
        {
            return _mCurrentMovement != direction;
        }
        #endregion

        public void Execute()
        {
            //Not implemented
        }
    }
}