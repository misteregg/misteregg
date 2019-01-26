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
                hero.Walk(Input.GetAxisRaw("Horizontal") / Math.Abs(Input.GetAxisRaw("Horizontal")));
            }

            if (Input.GetButtonDown("Jump"))
            {
                hero.Jump();
            }
        }
    }
}
