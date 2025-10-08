using Platformer.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneController
{
    public class SceneController : MonoBehaviour, ISceneController
    {
        [SerializeField] private string _levelScene;
        [SerializeField] private string _menuScene;

        private void Awake()
        {
            ServiceLocator.Instance.Set<ISceneController>(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Remove<ISceneController>();
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene(_levelScene);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(_menuScene);
        }
    }
}
