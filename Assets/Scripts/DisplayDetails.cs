using System;
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
        _panel = GameObject.FindGameObjectWithTag("panel");
        _title = GameObject.FindWithTag("title");
        _description = GameObject.FindWithTag("description");
    }

    private void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = department.icon;
        _panel.SetActive(false);
    }
    private void OnMouseDown()
    {
        // Debug.Log(GameObject.FindWithTag("panel"));
        if (_panel.activeSelf)
        {
            _panel.SetActive(false);
            if (_title.GetComponent<TextMeshProUGUI>().text == department.title)
            {
                return;
            }
        }

        _title.GetComponent<TextMeshProUGUI>().text = department.title;
        _description.GetComponent<TextMeshProUGUI>().text = department.description;

        _panel.SetActive(true);
    }
}