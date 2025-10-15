using Platformer.Common;
using Platformer.SceneController;
using UnityEngine;

namespace Platformer
{
    public class Events : MonoBehaviour
    {
        private ISceneController _sceneController;

        private void Start()
        {
            _sceneController = ServiceLocator.Instance.Get<ISceneController>();
        }

        public void Menu()
        {
            _sceneController.LoadMenu();
        }

        public void Level()
        {
            _sceneController.LoadLevel();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
