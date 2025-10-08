using System;

namespace Platformer.Health
{
    public interface IHealthSystem
    {
        int CurrentHealth { get; set; }
        void Damage();
        event Action<int> OnHealthChanged;
        event Action OnDeath;
    }
}