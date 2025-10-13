namespace Platformer.Player
{
    public interface IInputController
    {
        float GetMoveAxis();
        bool GetJumpInput();
        bool GetShootInput();
    }
}