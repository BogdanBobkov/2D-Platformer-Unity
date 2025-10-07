using System.Linq;
using Platformer.Common;
using Platformer.GameManager;
using Platformer.Health;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour, IHealthManager
{
    public GameObject damageEffect;

    private int MaxHealth = 6;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite FullHeartSprite;
    [SerializeField] private Sprite HalfHeartSprite;
    [SerializeField] private Sprite EmptyHeartSprite;

    private GameObject _player;

    private IHealthSystem _healthSystem;
    private IHealthVisual _healthVisual;

    private IGameManager _gameManager;
    private IPlayerController _playerController;

    private void Awake()
    {
        ServiceLocator.Instance.Set<IHealthManager>(this);

        _gameManager = ServiceLocator.Instance.Get<IGameManager>();

        _healthSystem = new HealthSystem();
        _healthSystem.OnDeath += OnDeath;
        _healthSystem.OnHealthChanged += OnHealthChanged;

        _healthVisual = new HealthVisual(hearts, FullHeartSprite, HalfHeartSprite, EmptyHeartSprite, damageEffect);
    }

    private void Start()
    {
        _player = FindObjectsOfType<MonoBehaviour>()
            .FirstOrDefault(m => m is IPlayerController)
            !.gameObject;

        _healthVisual.UpdateVisual(_healthSystem.CurrentHealth, _player.transform.position);
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
        _healthVisual.UpdateVisual(currentHealth, _player.transform.position);
    }

    public void Damage()
    {
        _healthSystem.Damage();
    }
}
