using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButtons : MonoBehaviour
{
    private float time = 10.0f;
    private float count = 0.0f;
    private bool collectData = false;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.X)) || (collectData == true))
        {
            if (count <= time)
            {
                // Set data collection to on while timer is still running
                collectData = true;
                // Return keys pressed in time period.
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
                    Debug.Log("Handshake initiated");
                }
                if (Input.GetButton("Fire2"))
                {
                    Debug.Log("Fire 2 pressed");
                }

                // count the time since last frame
                count += Time.deltaTime;
            }
            else
            {
                collectData = false;
                count = 0.0f;
            }
        }
    }
}
