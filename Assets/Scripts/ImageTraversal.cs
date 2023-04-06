using System;
using System.ComponentModel;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ImageTraversal : MonoBehaviour
{
    public TextAsset jsonFile;
    private Image _image;
    private NUST _nust;
    private DepartmentTraversals _departmentTraversals;
    private Traversal _current;

    [SerializeField] private GameObject leftButton, rightButton, backwardButton, forwardButton;
    [SerializeField] private String departmentName;
    public void moveTo(string position)
    {
        switch (position)
        {
            case "forward":
                FindAndSetNewTraversal(_current.forward);
                break;
            case "backward":
                FindAndSetNewTraversal(_current.backward);
                break;
            case "left":
                FindAndSetNewTraversal(_current.left);
                break;
            case "right":
                FindAndSetNewTraversal(_current.right);
                break;
        }
    }

    private void FindAndSetNewTraversal(string positionName)
    {
        foreach (var dept in _departmentTraversals.traversals)
        {
            if (dept.position != positionName) continue;
            Debug.Log("Called");
            SetTraversal(dept);
            break;
        }
    }

    private void SetTraversal(Traversal traversal)
    {
        _current = traversal;
        _image.sprite = LoadImageFromAsset(_current.position);
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        Debug.Log(_current.left);
        backwardButton.SetActive(_current.backward != null);
        forwardButton.SetActive(_current.forward != null);
        leftButton.SetActive(_current.left != null);
        rightButton.SetActive(_current.right != null);
    }

    // Start is called before the first frame update
    void Start()
    {
        _nust = JsonUtility.FromJson<NUST>(jsonFile.text);
        _image = GetComponent<Image>();
    }

    public void LoadInitial(string departmentName)
    {
        if (_nust == null)
        {
            _nust = JsonUtility.FromJson<NUST>(jsonFile.text);
            _image = GetComponent<Image>();
        }
        foreach (DepartmentTraversals dept in _nust.departmentTraversals)
        {
            if (dept.department != departmentName) continue;
            _departmentTraversals = dept;
            SetTraversal(dept.traversals[0]);
            break;
        }
    }

    private Sprite LoadImageFromAsset(string path)
    {
        var sprite =
            AssetDatabase.LoadAssetAtPath<Sprite>(
                $"Assets/Traversals/{_departmentTraversals.department}/{path}.jpeg");
        return sprite;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

[Serializable]
public class Traversal
{
    public string position, forward, backward, left, right;

    public Traversal(string position, string forward, string backward, string left, string right)
    {
        this.position = position;
        this.forward = forward;
        this.backward = backward;
        this.left = left;
        this.right = right;
    }
}

[Serializable]
public class DepartmentTraversals
{
    public string department;
    public Traversal[] traversals;

    public DepartmentTraversals(string department, Traversal[] traversals)
    {
        this.department = department;
        this.traversals = traversals;
    }
}

[Serializable]
public class NUST
{
    public DepartmentTraversals[] departmentTraversals;

    public NUST(DepartmentTraversals[] traversals)
    {
        departmentTraversals = traversals;
    }
}