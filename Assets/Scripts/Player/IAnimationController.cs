namespace Player
{
    public interface IAnimationController
    {
        void Update(float moveX, bool isGroundedBool);
        void Jump();
    }
}