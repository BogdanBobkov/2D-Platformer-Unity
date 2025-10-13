using ControlsManager;
using Platformer.Common;
using Platformer.GameManager;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float doubleJumpForce = 8f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGroundedBool = false;
    private bool canDoubleJump = false;

    public Animator playeranim;
    
    public bool isPaused = false;

    public ParticleSystem footsteps;

    public ParticleSystem ImpactEffect;
    private bool wasonGround;

    public float fireRate = 0.5f;
    private float moveX;

    private IControlsManager _controlsManager;
    private IGameManager _gameManager;
    
    private IMoveController _moveController;
    private IShootController _shootController;
    private IAnimationController _animationController;
    private IParticleController _particleController;
    private IInputController _inputController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controlsManager = ServiceLocator.Instance.Get<IControlsManager>();
        _gameManager = ServiceLocator.Instance.Get<IGameManager>();
        
        ServiceLocator.Instance.Set<IPlayerController>(this);

        _moveController = Application.isMobilePlatform
            ? new MobileMoveController()
            : new StandaloneMoveController(rb, groundLayer, groundCheck);

        _shootController = Application.isMobilePlatform
            ? new MobileShootController()
            : new StandaloneShootController(fireRate);

        _inputController = Application.isMobilePlatform
            ? new MobileInputController()
            : new StandaloneInputController();

        _animationController = new AnimationController(playeranim);
        _particleController = new ParticleController(footsteps, ImpactEffect);
    }

    private void Update()
    {
        isGroundedBool = _moveController.IsGrounded();
        if (isGroundedBool)
        {
            canDoubleJump = true;
            moveX = _inputController.GetMoveAxis();
            if (_inputController.GetJumpInput())
            {
                _moveController.Jump(jumpForce);
                _animationController.Jump();
            }
        }
        else
        {
            if (canDoubleJump && _inputController.GetJumpInput())
            {
                _moveController.Jump(doubleJumpForce);
                _animationController.Jump();
                canDoubleJump = false;
            }
        }

        if (!isPaused)
        {
            if (_inputController.GetShootInput())
            {
                _shootController.Shoot();
            }
        }

        _animationController.Update(moveX, isGroundedBool);
        _particleController.UpdateFootsteps(moveX, isGroundedBool);

        if (moveX != 0)
        {
            FlipSprite(moveX);
        }

        if (!wasonGround && isGroundedBool)
        {
            _particleController.UpdateImpactEffect();
        }

        wasonGround = isGroundedBool;
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Remove<IPlayerController>();
    }

    private void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        moveX = _inputController.GetMoveAxis();
        _moveController.Move(moveX, moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("killzone"))
        {
            _gameManager.Death();
        }
    }

    public Vector3 GetPosition() => transform.position;
    public void SetPosition(Vector3 position) => transform.position = position;
    public GameObject GetGameObject() => gameObject;
}