using System;
using UnityEngine;
using TMPro;

public class DisplayDetails : MonoBehaviour
{
    public Department department;
    private GameObject _panel;
    private GameObject _title;
    private GameObject _description;

    [SerializeField] private float scalingFactor=1.1f;
    private void Awake()
    {
        _panel = GameObject.FindWithTag("panel");
        Debug.Log(_panel.name);
        _title = GameObject.FindWithTag("title");
        _description = GameObject.FindWithTag("description");
    }

    private void Start()
    {
        // _panel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,-1200);
        // _panel.SetActive(false);
    }
    public void MouseDown()
    {
        Animator animator = _panel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("show");
        Debug.Log("CALLED");
        // Debug.Log(GameObject.FindWithTag("panel"));
        if (isOpen)
        {
            animator.SetBool("show",false);
            if (_title.GetComponent<TextMeshProUGUI>().text == department.title)
            {
                return;
            }
        }

        _title.GetComponent<TextMeshProUGUI>().text = department.title;
        _description.GetComponent<TextMeshProUGUI>().text = department.description;

        
        Debug.Log(_panel.activeSelf);
        animator.SetBool("show",true);
        Debug.Log(_panel.activeSelf);
    }

    public void MouseEnter()
    {
        this.GetComponent<Animator>().SetBool("scale",true);
        // transform.localScale = new Vector3(scalingFactor, scalingFactor, 1);
    }

    public void MouseLeave()
    {
        this.GetComponent<Animator>().SetBool("scale",false);
        // transform.localScale = new Vector3(1, 1, 1);
    }
}