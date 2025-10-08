using UnityEngine;
using TMPro;
using System.Collections;
using ControlsManager;
using Platformer.Common;
using Platformer.Pickup;
using Player;
using SceneController;
using Ui;

namespace Platformer.GameManager
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private TMP_Text coinText;
        [SerializeField] GameObject levelCompletePanel;
        [SerializeField] TMP_Text leveCompletePanelTitle;
        [SerializeField] TMP_Text levelCompleteCoins;

        private bool isGameOver;
        private Vector3 playerPosition;

        private IUiManager _uiManager;
        private ISceneController _sceneController;
        private IControlsManager _controlsManager;
        private IPlayerController _playerController;
        private IPickupTracker _pickupTracker;
        private IHudController _hudController;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _hudController =
                new HudController(coinText, levelCompletePanel, leveCompletePanelTitle, levelCompleteCoins);
            _pickupTracker = new PickupTracker();
            
            ServiceLocator.Instance.Set<IGameManager>(this);
        }

        private void Start()
        {
            _uiManager = ServiceLocator.Instance.Get<IUiManager>();
            _controlsManager = ServiceLocator.Instance.Get<IControlsManager>();
            _playerController = ServiceLocator.Instance.Get<IPlayerController>();
            _sceneController = ServiceLocator.Instance.Get<ISceneController>();
            
            UpdateGUI();
            _uiManager.SetFadeFromBlack(true);
            playerPosition = _playerController.GetPosition();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Remove<IGameManager>();
        }

        private void UpdateGUI()
        {
            _hudController.Update(_pickupTracker.GetTotalCount(typeof(CoinPickup)));
        }

        public void IncrementPickup(PickupBase pickup)
        {
            _pickupTracker.IncrementPickup(pickup);
            UpdateGUI();
        }

        public void Death()
        {
            if (!isGameOver)
            {
                _controlsManager.DisableMobileControls();
                _uiManager.SetFadeToBlack(true);
                _playerController.GetGameObject().SetActive(false);
                StartCoroutine(DeathCoroutine());
                isGameOver = true;
            }
        }

        public void LevelComplete()
        {
            _hudController.SetLevelCompletedHud(_pickupTracker.GetTotalCount(typeof(CoinPickup)));
        }

        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(1f);

            _playerController.SetPosition(playerPosition);

            // Wait for 2 seconds
            yield return new WaitForSeconds(1f);

            // Check if the game is still over (in case player respawns earlier)
            if (isGameOver)
            {
                _sceneController.LoadLevel();
            }
        }
    }
}