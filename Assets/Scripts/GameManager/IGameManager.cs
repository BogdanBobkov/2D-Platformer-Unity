namespace Platformer.GameManager
{
    public interface IGameManager
    {
        void IncrementCoinCount();
        void IncrementGemCount();
        void Death();
        void FindTotalPickups();
        void LevelComplete();
    }
}