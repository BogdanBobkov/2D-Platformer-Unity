using Platformer.Common;
using UnityEngine;

namespace ControlsManager
{
    public enum Controls
    {
        mobile,
        pc
    }

    public class ControlsManager : MonoBehaviour, IControlsManager
    {
        [SerializeField] private Controls _controls;

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

        public Controls GetControlsType() => _controls;
    }
}