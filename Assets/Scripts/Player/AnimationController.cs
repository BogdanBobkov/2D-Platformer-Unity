using UnityEngine;

namespace Player
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
            if (moveX != 0 && isGroundedBool)
            {
                _animator.SetBool("run", true);
            }
            else
            {
                _animator.SetBool("run", false);
            }
            _animator.SetBool("isGrounded", isGroundedBool);
        }

        public void Jump()
        {
            _animator.SetTrigger("jump");
        }
    }
}