namespace Ui
{
    public interface IFadeHandler
    {
        void Update();
        void SetFadeToBlack(bool state);
        void SetFadeFromBlack(bool state);
    }
}