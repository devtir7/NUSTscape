using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayHamburger : MonoBehaviour
{
    private GameObject _menu;


    private void Awake()
    {
        _menu = GameObject.FindWithTag("hamburger");
        Debug.Log(_menu.name);
    }

    public void MouseDown()
    {
        Animator animator = _menu.GetComponent<Animator>();
        bool isOpen = animator.GetBool("show");
        Debug.Log("CALLED");
        // Debug.Log(GameObject.FindWithTag("menu"));
        if (isOpen)
        {
            animator.SetBool("show", false);
            return;
        }

        animator.SetBool("show", true);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
