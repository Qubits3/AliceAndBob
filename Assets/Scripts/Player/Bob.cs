using UnityEngine;

namespace Player
{
    public class Bob : PlayerBase
    {
        protected override void Special()
        {
            GroundBreaker();
        }

        private void GroundBreaker()
        {
            canSpecialPerform = false;
            playerRigidbody2D.velocity = new Vector2(0, -breakSpeed);
        }
    
        protected override void Attack()
        {
            Debug.Log("Bob is attacking");
        }
    }
}