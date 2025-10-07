using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class FadeHandler : IFadeHandler
    {
        private readonly Image _blackScreen;
        private readonly float _fadeSpeed;
        
        private bool _fadeToBlack;
        private bool _fadeFromBlack;

        public FadeHandler(bool fadeToBlack, bool fadeFromBlack, Image blackScreen, float fadeSpeed)
        {
            _fadeToBlack = fadeToBlack;
            _fadeFromBlack = fadeFromBlack;
            _blackScreen = blackScreen;
            _fadeSpeed = fadeSpeed;
        }

        public void Update()
        {
            UpdateFade();
        }

        public void SetFadeToBlack(bool state)
        {
            _fadeToBlack = state;
        }

        public void SetFadeFromBlack(bool state)
        {
            _fadeFromBlack = state;
        }

        private void UpdateFade()
        {
            if (_fadeToBlack)
            {
                FadeToBlack();
            }
            else if (_fadeFromBlack)
            {
                FadeFromBlack();
            }
        }

        private void FadeToBlack()
        {
            FadeScreen(1f);

            if (_blackScreen.color.a >= 1f)
            {
                _fadeToBlack = false;
            }
        }

        private void FadeFromBlack()
        {
            FadeScreen(0f);

            if (_blackScreen.color.a <= 0f)
            {
                _fadeFromBlack = false;
            }
        }

        private void FadeScreen(float targetAlpha)
        {
            Color currentColor = _blackScreen.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, _fadeSpeed * Time.deltaTime);
            _blackScreen.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }
}