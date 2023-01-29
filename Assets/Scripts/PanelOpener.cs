using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        Debug.Log("pls");
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
}
