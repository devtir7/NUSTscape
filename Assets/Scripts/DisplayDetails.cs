using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayDetails : MonoBehaviour
{
    public Department department;
    private GameObject _panel;
    private GameObject _title;
    private GameObject _description;
    private GameObject _btn;
    private GameObject _map;
    private GameObject _mapTraversal;
    private GameObject _image;

    private void Awake()
    {
        _map = GameObject.FindWithTag("map");
        _mapTraversal = GameObject.FindWithTag("traversal");
        _image = GameObject.FindWithTag("image");
        _panel = GameObject.FindWithTag("panel");
        _title = GameObject.FindWithTag("title");
        _description = GameObject.FindWithTag("description");
        _btn=GameObject.FindWithTag("btn");
    }

    private void Start()
    {
        _mapTraversal.SetActive(false);
    }

    public void MouseDown()
    {
        Animator animator = _panel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("show");
        // Debug.Log(GameObject.FindWithTag("panel"));
        if (isOpen)
        {
            animator.SetBool("show", false);
            if (_title.GetComponent<TextMeshProUGUI>().text == department.title)
            {
                return;
            }
        }
        PanCameraToDepartment();
        _title.GetComponent<TextMeshProUGUI>().text = department.title;
        _description.GetComponent<TextMeshProUGUI>().text = department.description;
        _btn.GetComponent<Button>().onClick.RemoveAllListeners();
        _btn.GetComponent<Button>().onClick.AddListener(OnClick);
        animator.SetBool("show", true);
    }

    private void OnClick()
    {
        _map.SetActive(false);
        _mapTraversal.SetActive(true);
        Debug.Log(gameObject.name);
        Debug.Log(_image.name);
        _image.GetComponent<ImageTraversal>().LoadInitial(gameObject.name);
    }
    
    private void PanCameraToDepartment()
    {
        Camera camera = Camera.main;
        GameObject.FindWithTag("MainCamera").transform.position = new Vector3(transform.position.x ,transform.position.y,
            camera.transform.position.z);
        Debug.Log(camera.transform.position);
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