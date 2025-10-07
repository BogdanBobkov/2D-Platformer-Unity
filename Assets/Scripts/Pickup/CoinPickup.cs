using Platformer.Common;
using Platformer.GameManager;
using UnityEngine;

namespace Platformer.Pickup
{
    public class CoinPickup : PickupBase
    {
        private IGameManager _gameManager;
        
        private void Awake()
        {
            _gameManager = ServiceLocator.Instance.Get<IGameManager>();
        }

        protected override void OnTriggerEnterHandler()
        {
            _gameManager.IncrementCoinCount();
            Instantiate(PickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject,0.2f);
        }
    }
}