using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSqueak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Squeak()
    {
        Debug.Log("Squeaked");
        GetComponent<AudioSource>().Play(0);
    }
}
