using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonHintBehavior : MonoBehaviour
{

    private Animator animator;
    public GameObject interactButton;
    

    public void HideHintAnimation()
    {
        animator.SetBool("isActive", false);
    }

    public void ShowHintAnimation()
    {
        animator.SetBool("isActive", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("isActive", interactButton.activeSelf);
    }
}
