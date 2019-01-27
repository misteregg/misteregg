using UnityEngine;

namespace Object
{
    public class ObjectBehaviour : MonoBehaviour
    {
        public GameObject interactButton;

        private InteractButtonHintBehavior interactButtonHintBehavior;

        private void Start()
        {
            interactButtonHintBehavior = interactButton.GetComponent<InteractButtonHintBehavior>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            interactButtonHintBehavior.ShowHintAnimation();
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            interactButtonHintBehavior.HideHintAnimation();
        }
    }
}
