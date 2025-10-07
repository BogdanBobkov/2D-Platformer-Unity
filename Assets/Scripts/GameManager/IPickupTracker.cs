using System;
using Platformer.Pickup;

namespace Platformer.GameManager
{
    public interface IPickupTracker
    {
        void IncrementPickup(PickupBase pickupBase);
        int GetTotalCount(Type pickupType);
    }
}