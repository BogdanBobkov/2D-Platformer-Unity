namespace Player
{
    public interface IMoveController
    {
        float GetMoveAxis();
        bool IsJump();
        void Jump(float jumpForce);
        bool IsGrounded();
    }
}