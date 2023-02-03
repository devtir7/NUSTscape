using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            
        }
    }
}
