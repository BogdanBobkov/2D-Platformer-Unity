using System;
using System.Collections.Generic;
using Platformer.Pickup;

namespace Platformer.GameManager
{
    public class PickupTracker : IPickupTracker
    {
        private readonly Dictionary<Type, int> _pickups = new();
        
        public void IncrementPickup(PickupBase pickupBase)
        {
            _pickups[pickupBase.GetType()]++;
        }

        public int GetTotalCount(Type pickupType) => _pickups.ContainsKey(pickupType) ? _pickups[pickupType] : 0;
    }
}