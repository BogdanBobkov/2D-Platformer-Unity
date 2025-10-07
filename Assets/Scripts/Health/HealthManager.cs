using Platformer.Common;
using Platformer.GameManager;
using Platformer.Health;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour, IHealthManager
{
    public GameObject damageEffect;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite FullHeartSprite;
    [SerializeField] private Sprite HalfHeartSprite;
    [SerializeField] private Sprite EmptyHeartSprite;

    private IHealthSystem _healthSystem;
    private IHealthVisual _healthVisual;

    private IGameManager _gameManager;
    private IPlayerController _playerController;

    private void Awake()
    {
        ServiceLocator.Instance.Set<IHealthManager>(this);

        _healthSystem = new HealthSystem();
        _healthSystem.OnDeath += OnDeath;
        _healthSystem.OnHealthChanged += OnHealthChanged;

        _healthVisual = new HealthVisual(hearts, FullHeartSprite, HalfHeartSprite, EmptyHeartSprite, damageEffect);
    }

    private void Start()
    {
        _gameManager = ServiceLocator.Instance.Get<IGameManager>();
        _playerController = ServiceLocator.Instance.Get<IPlayerController>();
        
        _healthVisual.UpdateVisual(_healthSystem.CurrentHealth, _playerController.GetPosition());
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Remove<IHealthManager>();
        _healthSystem.OnDeath -= OnDeath;
        _healthSystem.OnHealthChanged -= OnHealthChanged;
    }

    private void OnDeath()
    {
        _gameManager.Death();
    }

    private void OnHealthChanged(int currentHealth)
    {
        _healthVisual.UpdateVisual(currentHealth, _playerController.GetPosition());
    }

    public void Damage()
    {
        _healthSystem.Damage();
    }
}
