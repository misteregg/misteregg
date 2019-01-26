using UnityEngine;

namespace Object
{
    public class ObjectBehaviour : MonoBehaviour
    {
        public GameObject interactButton;

        private void Start()
        {
            interactButton.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            interactButton.SetActive(true);
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            interactButton.SetActive(false);
        }
    }
}
