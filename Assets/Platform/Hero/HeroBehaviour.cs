using UnityEngine;

namespace Platform.Hero
{
    public class HeroBehaviour : MonoBehaviour
    {
        public float speed = 5;
        public float terminalVelocity = -10;
        private Rigidbody2D rb2d;
        private UserInput input;

        private float horizontalPush = 0;
        private float verticalPush = 0;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            input = new UserInput(this);
        }

        void FixedUpdate()
        {
            input.Update();

            float moveVertical = verticalPush > 0
                ? verticalPush
                : Mathf.Max(rb2d.velocity.y, terminalVelocity);
            float moveHorizontal = horizontalPush;

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.velocity = movement;

            verticalPush = 0;
            horizontalPush = 0;
            moveHorizontal = 0;
        }

        public void Walk(float moveHorizontal)
        {
            horizontalPush = moveHorizontal * speed;
        }

        public void Jump()
        {
            verticalPush = 10;
        }
    }
}
