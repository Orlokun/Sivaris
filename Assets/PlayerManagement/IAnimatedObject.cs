using PlayerManagement.Commands;
using UnityEngine;

namespace PlayerManagement
{
    public interface IAnimatedObject
    {
        public Animator Animator { get; }
        public void ChangeAnimationState(BaseMovementAnimations newAnimState);
        public BaseMovementAnimations GetCurrentAnim();
        public float GetCurrentAnimationLength();
        public bool IsAnimationAvailable(BaseMovementAnimations animState);
    }
}