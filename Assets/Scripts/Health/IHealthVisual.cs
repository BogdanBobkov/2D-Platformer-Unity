using UnityEngine;

namespace Platformer.Health
{
    public interface IHealthVisual
    {
        void UpdateVisual(int currentHealth, Vector3 position);
    }
}