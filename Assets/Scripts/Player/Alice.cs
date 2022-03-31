using UnityEngine;

namespace Player
{
    public class Alice : PlayerBase
    {
        [SerializeField] private float dashPower;
        [SerializeField] private float maxDashingTime;
        private float _currentDashTime;
    
        private Vector3 _facing = Vector3.right;
    
        protected override void Update()
        {
            base.Update();
        
            if (isSpecialPerforming)
            {
                playerRigidbody2D.velocity = new Vector2(dashPower * _facing.x, 0);

                _currentDashTime -= Time.deltaTime;

                if (_currentDashTime <= 0)
                {
                    StopDashing();
                }
            }
        }
    
        private void FixedUpdate()
        {
            var tempFacing = HorizontalMovement();

            if (tempFacing != Vector3.zero)
            {
                _facing = tempFacing;
            }
        }

        protected override void Special()
        {
            ForwardDash();
        }

        protected override void Attack()
        {
            Debug.Log("Alice is attacking");
        }

        private void ForwardDash()
        {
            canSpecialPerform = false;
            isSpecialPerforming = true;
        
            _currentDashTime = maxDashingTime;
            ZeroVelocity();
        }

        private void StopDashing()
        {
            isSpecialPerforming = false;
            ZeroVelocity();
        }
    
        private void ZeroVelocity()
        {
            playerRigidbody2D.velocity = Vector2.zero;
        }
    }
}