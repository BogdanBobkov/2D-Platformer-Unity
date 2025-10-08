using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Health
{
    public class HealthVisual : IHealthVisual
    {
        private readonly Image[] _hearts;
        private readonly Sprite _fullHeartSprite;
        private readonly Sprite _halfHeartSprite;
        private readonly Sprite _emptyHeartSprite;
        private readonly GameObject _damageEffect;

        public HealthVisual(Image[] hearts, Sprite fullHeartSprite, Sprite halfHeartSprite, Sprite emptyHeartSprite,
            GameObject damageEffect)
        {
            _hearts = hearts;
            _fullHeartSprite = fullHeartSprite;
            _halfHeartSprite = halfHeartSprite;
            _emptyHeartSprite = emptyHeartSprite;
            _damageEffect = damageEffect;
        }

        public void UpdateVisual(int currentHealth, Vector3 position)
        {
            var fullHeartsCount = currentHealth / 2;
            var hasHalfHeart = currentHealth % 2 == 1;

            for (var i = 0; i < _hearts.Length; i++)
            {
                if (i < fullHeartsCount)
                {
                    _hearts[i].sprite = _fullHeartSprite;
                }
                else if (hasHalfHeart && i == fullHeartsCount)
                {
                    _hearts[i].sprite = _halfHeartSprite;
                }
                else
                {
                    _hearts[i].sprite = _emptyHeartSprite;
                }
            }

            Object.Instantiate(_damageEffect, position, Quaternion.identity);
        }
    }
}