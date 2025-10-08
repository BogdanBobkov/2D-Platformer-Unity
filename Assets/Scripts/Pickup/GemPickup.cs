using Platformer.Common;
using Platformer.GameManager;
using UnityEngine;

namespace Platformer.Pickup
{
    public class GemPickup : PickupBase
    {
        private IGameManager _gameManager;

        private void Start()
        {
            _gameManager = ServiceLocator.Instance.Get<IGameManager>();
        }

        protected override void OnTriggerEnterHandler()
        {
            _gameManager.IncrementPickup(this);
            Instantiate(PickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }
    }
}