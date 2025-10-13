using Platformer.Common;
using UnityEngine;

namespace Platformer.Player
{
    public class AnimationController : IAnimationController
    {
        private readonly Animator _animator;

        public AnimationController(Animator animator)
        {
            _animator = animator;
        }
        
        public void Update(float moveX, bool isGroundedBool)
        {
            _animator.SetBool(AnimationConstants.RunAnimationKey, moveX != 0 && isGroundedBool);
            _animator.SetBool(AnimationConstants.IsGroundedAnimationKey, isGroundedBool);
        }

        public void Jump()
        {
            _animator.SetTrigger(AnimationConstants.JumpAnimationKey);
        }
    }
}