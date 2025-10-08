namespace Platformer.GameManager
{
    public interface IHudController
    {
        public void SetLevelCompletedHud(int count);
        public void Update(int count);
    }
}