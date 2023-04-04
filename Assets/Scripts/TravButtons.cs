using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravButtons : MonoBehaviour
{
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
