using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Up pressed");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Down pressed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left pressed");
        }
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump pressed");
        }
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire 1 pressed");
        }
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Fire 2 pressed");
        }
    }
}
