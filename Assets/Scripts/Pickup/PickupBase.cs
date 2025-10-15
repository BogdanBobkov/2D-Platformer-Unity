using Platformer.Common;
using UnityEngine;

namespace Platformer.Pickup
{
    public abstract class PickupBase : MonoBehaviour
    {
        [SerializeField] protected GameObject PickupEffect;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(TagConstants.PlayerTag))
            {
                OnTriggerEnterHandler();
            }
        }

        protected abstract void OnTriggerEnterHandler();
    }
}
