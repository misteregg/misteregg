using UnityEngine;

namespace Object
{
    public class ObjectBehaviour : MonoBehaviour
    {
        public GameObject interactButton;

        private int fois = 0;

        private void Start()
        {
            interactButton.SetActive(false);
        }

        void Update()
        {
            if (interactButton.activeSelf
                && Input.GetButtonDown("Fire1")) {
                Interact();
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            interactButton.SetActive(true);
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            interactButton.SetActive(false);
        }

        void Interact()
        {
            Debug.Log("FOI " + (fois++));
        }
    }
}
