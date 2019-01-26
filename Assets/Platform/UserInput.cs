using System;
using Platform.Hero;
using UnityEngine;

namespace Platform
{
    public class UserInput
    {
        public HeroBehaviour hero;

        public UserInput(HeroBehaviour hero)
        {
            this.hero = hero;
        }

        public void Update()
        {
            if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                int walkDirection = (int) Math.Floor(Input.GetAxisRaw("Horizontal") / Math.Abs(Input.GetAxisRaw("Horizontal")));
                hero.Walk(walkDirection);
            }

            if (Input.GetButtonDown("Jump"))
            {
                hero.Jump();
            }
        }
    }
}
