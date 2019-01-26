using UnityEngine;

namespace Platform.Hero
{
    public class HeroBehaviour : MonoBehaviour
    {
        public float speed;
        public float jumpSpeed;

        float moveVelocity;
        float fallSpeed;

        int direction;
        bool willJump;

        bool isGrounded = true;

        Rigidbody2D body;
        UserInput input;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            input = new UserInput(this);
        }

        void Update()
        {
            input.Update();
            UpdatePhysics();

            ResetVariables();
        }

        public void Walk(int direction)
        {
            this.direction = direction;
        }

        public void Jump()
        {
            if (!canJump())
            {
                return;
            }

            willJump = true;
            isGrounded = false;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            isGrounded = true;
        }

        void UpdatePhysics()
        {
            moveVelocity = 0;
            fallSpeed = willJump ? jumpSpeed : body.velocity.y;

            moveVelocity = speed * direction;

            body.velocity = new Vector2(moveVelocity, fallSpeed);
        }

        void ResetVariables()
        {
            direction = 0;
            willJump = false;
        }

        bool canJump()
        {
            return isGrounded;
        }
    }
}
