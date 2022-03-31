using Input;
using UnityEngine;

namespace Player
{
    public abstract class PlayerBase : MonoBehaviour
    {
        [SerializeField] private float jumpingPower;
        [SerializeField] protected float breakSpeed;
        [SerializeField] private float walkingSpeed;
    
        private BoxCollider2D _playerCollider;
        [SerializeField] private LayerMask jumpableGround;

        private PlayerInput _playerInput;

        private int _jumpCount;

        protected bool canSpecialPerform;
        protected bool isSpecialPerforming;
        private bool _isJumping;

        protected Rigidbody2D playerRigidbody2D;

        private void Awake()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
            _playerCollider = GetComponent<BoxCollider2D>();
        }

        protected virtual void Update()
        {
#if UNITY_EDITOR
            KeyboardJump();
#endif
            if (_playerInput.AttackButtonInput)
            {
                Attack();
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
                playerRigidbody2D.AddForce(new Vector2(0, jumpingPower), ForceMode2D.Impulse);
                _jumpCount++;
            }
            else if (canSpecialPerform)
            {
                canSpecialPerform = false;
                Special();
            }
        }
    
        private void OnCollisionEnter2D()
        {
            _jumpCount = 0;
            canSpecialPerform = true;
        }

        protected Vector3 HorizontalMovement()
        {
            var lastLookRotation = Vector3.zero;

            if (_playerInput.RightButtonInput)
            {
                return MoveCharacter(Vector3.right);
            }

            if (_playerInput.LeftButtonInput)
            {
                return MoveCharacter(Vector3.left);
            }

            return lastLookRotation;
        }

        private Vector3 MoveCharacter(Vector3 forceDirection)
        {
            transform.Translate(forceDirection * (Time.deltaTime * walkingSpeed));

            return forceDirection;
        }

        protected abstract void Special();

        protected abstract void Attack();
    }
}