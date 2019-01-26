using UnityEngine;

namespace Platform.Hero
{
    public class HeroBehaviour : MonoBehaviour
    {
        public float speed;
        public float jumpSpeed;
        public int jumpCountLimit = 1;

        float moveVelocity;
        float fallSpeed;

        int direction;
        int lastDirection = 1;
        bool willJump;

        int jumpCount = 0;

        Rigidbody2D body;
        UserInput input;
        Animator animator;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            input = new UserInput(this);
        }

        void Update()
        {
            input.Update();
            UpdatePhysics();
            UpdateAnimation();

            ResetVariables();
        }

        public void Walk(int direction)
        {
            this.direction = direction;
        }

        public void Jump()
        {
            if (!CanJump())
            {
                return;
            }

            willJump = true;
            jumpCount++;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            jumpCount = 0;
        }

        void UpdatePhysics()
        {
            fallSpeed = willJump ? jumpSpeed : body.velocity.y;

            moveVelocity = speed * direction;

            body.velocity = new Vector2(moveVelocity, fallSpeed);
        }

        void UpdateAnimation()
        {
            animator.SetBool("isIdle", direction == 0);
            animator.SetBool("isJumping", jumpCount > 0);
            UpdateAnimationDirection();
        }

        void UpdateAnimationDirection()
        {
            if (direction != 0)
            {
                lastDirection = direction;
            }

            Vector3 scale = animator.transform.localScale;
            scale.x = lastDirection;
            animator.transform.localScale = scale;
        }

        void ResetVariables()
        {
            direction = 0;
            willJump = false;
        }

        bool CanJump()
        {
            return jumpCount < jumpCountLimit;
        }
    }
}
