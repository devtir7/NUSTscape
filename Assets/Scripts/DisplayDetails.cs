using UnityEngine;
using TMPro;

public class DisplayDetails : MonoBehaviour
{
    public Department department;
    private GameObject _panel;
    private GameObject _title;
    private GameObject _description;

    private void Awake()
    {
        _panel = GameObject.FindWithTag("panel");
        Debug.Log(_panel.name);
        _title = GameObject.FindWithTag("title");
        _description = GameObject.FindWithTag("description");
    }

    public void MouseDown()
    {
        Animator animator = _panel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("show");
        Debug.Log("CALLED");
        // Debug.Log(GameObject.FindWithTag("panel"));
        if (isOpen)
        {
            animator.SetBool("show", false);
            if (_title.GetComponent<TextMeshProUGUI>().text == department.title)
            {
                return;
            }
        }

        _title.GetComponent<TextMeshProUGUI>().text = department.title;
        _description.GetComponent<TextMeshProUGUI>().text = department.description;

        animator.SetBool("show", true);
    }

    public void MouseEnter()
    {
        //Start scaling animation
        GetComponent<Animator>().SetBool("scale", true);
    }

    public void MouseLeave()
    {
        //reverse scaling animation
        GetComponent<Animator>().SetBool("scale", false);
    }
}