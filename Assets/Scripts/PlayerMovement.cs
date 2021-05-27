using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpingPower;
    [SerializeField] private float breakSpeed;
    [SerializeField] private float walkingSpeed;

    [SerializeField] private float dashPower;
    [SerializeField] private float maxDashingTime;
    private float _currentDashTime;

    private PlayerInput _playerInput;

    private int _jumpCount;

    private bool _canSpecialPerform;
    private bool _isSpecialPerforming;
    private bool _isJumping;

    private Rigidbody2D _rigidbody2D;

    private Vector3 _tempFacing;
    private Vector3 _facing = Vector3.right;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        _tempFacing = HorizontalMovement(); // We called it in FixedUpdate to prevent flickering

        if (_tempFacing != Vector3.zero)
        {
            _facing = _tempFacing;
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        KeyboardJump();
#endif
        Attack();

        if (_isSpecialPerforming)
        {
            _rigidbody2D.velocity = new Vector2(dashPower * _facing.x, 0);

            _currentDashTime -= Time.deltaTime;

            if (_currentDashTime <= 0)
            {
                StopDashing();
            }
        }
    }

    private void KeyboardJump()
    {
        if (_playerInput.JumpButtonInput)
        {
            JoystickJump();
        }
    }

    public void JoystickJump()
    {
        if (_jumpCount == 0)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpingPower), ForceMode2D.Impulse);
            _jumpCount++;
        }
        else if (_canSpecialPerform)
        {
            _canSpecialPerform = false;
            if (gameObject.tag.Equals("Alice"))
            {
                ForwardDash();
            }
            else
            {
                GroundBreaker();
            }
        }
    }

    private Vector3 HorizontalMovement()
    {
        var lastLookRotation = Vector3.zero;

        if (_playerInput.RightButtonInput)
        {
            MoveCharacter(Vector3.right);

            lastLookRotation = Vector3.right;

            return lastLookRotation;
        }

        if (_playerInput.LeftButtonInput)
        {
            MoveCharacter(Vector3.left);

            lastLookRotation = Vector3.left;

            return lastLookRotation;
        }

        return lastLookRotation;
    }

    private void MoveCharacter(Vector3 forceDirection)
    {
        transform.Translate(forceDirection * (Time.deltaTime * walkingSpeed));
    }

    private void OnCollisionEnter2D()
    {
        _jumpCount = 0; // Set to zero so character can jump again
        _canSpecialPerform = true;
    }

    private void Attack()
    {
        if (_playerInput.AttackButtonInput)
        {
            Debug.Log("Attacking");
        }
    }

    private void GroundBreaker()
    {
        _canSpecialPerform = false;
        _rigidbody2D.velocity = new Vector2(0, -breakSpeed);
    }

    private void ForwardDash()
    {
        _canSpecialPerform = false;
        _currentDashTime = maxDashingTime;
        _rigidbody2D.velocity = Vector2.zero;
        _isSpecialPerforming = true;
    }

    private void StopDashing()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _isSpecialPerforming = false;
    }
}