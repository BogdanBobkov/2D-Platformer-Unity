namespace Platformer.Player
{
    public interface IMoveController
    {
        void Jump(float jumpForce);
        bool IsGrounded();
        void Move(float moveX, float moveSpeed);
    }
}