using UnityEngine;

namespace Platformer.Player
{
    public interface IPlayerController
    {
        Vector3 GetPosition();
        void SetPosition(Vector3 position);
        GameObject GetGameObject();
    }
}