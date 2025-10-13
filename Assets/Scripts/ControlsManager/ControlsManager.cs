using Platformer.Common;
using UnityEngine;

namespace Platformer.ControlsManager
{
    public class ControlsManager : MonoBehaviour, IControlsManager
    {
        public GameObject mobileControls;

        private void Awake()
        {
            ServiceLocator.Instance.Set<IControlsManager>(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Remove<IControlsManager>();
        }

        public void DisableMobileControls()
        {
            mobileControls.SetActive(false);
        }

        public void EnableMobileControls()
        {
            mobileControls.SetActive(true);
        }
    }
}