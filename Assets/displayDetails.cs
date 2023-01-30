using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayDetails : MonoBehaviour
{
    public Building building;

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    void Start()
    {
        nameText.text = building.name;
        descriptionText.text = building.description;
    }
}
