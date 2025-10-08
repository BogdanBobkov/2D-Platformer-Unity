using System;

namespace Platformer.Health
{
    public class HealthSystem : IHealthSystem
    {
        private const int MaxHealth = 6;

        public int CurrentHealth { get; set; } = MaxHealth;

        public void Damage()
        {
            if (CurrentHealth > 0)
            {
                CurrentHealth--;
            }
            else if (CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
            }

            OnHealthChanged?.Invoke(CurrentHealth);
        }

        public event Action<int> OnHealthChanged;
        public event Action OnDeath;
    }
}