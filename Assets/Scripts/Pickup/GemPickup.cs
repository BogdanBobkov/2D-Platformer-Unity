using Platformer.Common;
using Platformer.GameManager;
using UnityEngine;

namespace Platformer.Pickup
{
    public class GemPickup : PickupBase
    {
        private IGameManager _gameManager;

        private void Awake()
        {
            _gameManager = ServiceLocator.Instance.Get<IGameManager>();
        }

        protected override void OnTriggerEnterHandler()
        {
            _gameManager.IncrementGemCount();
            Instantiate(PickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }
    }
}