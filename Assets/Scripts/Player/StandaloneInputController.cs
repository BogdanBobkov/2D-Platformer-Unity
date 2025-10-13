using UnityEngine;

namespace Platformer.Player
{
    public class StandaloneInputController : IInputController
    {
        public float GetMoveAxis()
        {
            return Input.GetAxis("Horizontal");
        }

        public bool GetJumpInput()
        {
            return Input.GetButtonDown("Jump");
        }
        
        public bool GetShootInput()
        {
            return Input.GetButtonDown("Fire1");
        }
    }
}