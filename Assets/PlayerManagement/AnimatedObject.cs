using System.Collections.Generic;
using PlayerManagement.Commands;
using UnityEngine;

namespace PlayerManagement
{
    public class AnimatedObject : IAnimatedObject
    {
        private BaseMovementAnimations _mCurrentAnimState;
        public Animator Animator => _mAnim;
        private Animator _mAnim;
        private Dictionary<BaseMovementAnimations, string> _mAnimations;

        public AnimatedObject(Animator mAnim, Dictionary<BaseMovementAnimations, string> anims)
        {
            _mAnim = mAnim;
            _mAnimations = anims;
            ChangeAnimationState(BaseMovementAnimations.IdleUp);
        }
        
        public void ChangeAnimationState(BaseMovementAnimations newAnimState)
        {
            if (!IsAnimationAvailable(newAnimState))
            {
                return;
            }
            _mCurrentAnimState = newAnimState;
            Animator.Play(_mAnimations[_mCurrentAnimState]);
        }
        
        public BaseMovementAnimations GetCurrentAnim()
        {
            return _mCurrentAnimState;
        }

        public float GetCurrentAnimationLength()
        {
            throw new System.NotImplementedException();
        }

        public bool IsAnimationAvailable(BaseMovementAnimations animState)
        {
            return _mAnimations.ContainsKey(animState);
        }
    }
}