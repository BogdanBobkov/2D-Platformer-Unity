using UnityEngine;

namespace Platformer.Player
{
    public class StandaloneInputController : IInputController
    {
        private const string HorizontalButtonName = "Horizontal";
        private const string JumpButtonName = "Jump";
        private const string FireButtonName = "Fire1";
        
        public float GetMoveAxis()
        {
            return Input.GetAxis(HorizontalButtonName);
        }

        public bool GetJumpInput()
        {
            return Input.GetButtonDown(JumpButtonName);
        }
        
        public bool GetShootInput()
        {
            return Input.GetButtonDown(FireButtonName);
        }
    }
}