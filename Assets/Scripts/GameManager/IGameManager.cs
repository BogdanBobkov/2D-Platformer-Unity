using Platformer.Pickup;

namespace Platformer.GameManager
{
    public interface IGameManager
    {
        void IncrementPickup(PickupBase pickup);
        void Death();
        void LevelComplete();
    }
}