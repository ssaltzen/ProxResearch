using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    private RoomSpecs room;
    // Update is called once per frame

    void Awake()
    {
        room = new RoomSpecs();
    }

    void Update()
    {
        //room.SetLength(slider1.value);
        //room.SetWidth(slider2.value);
        //room.SetHeight(slider3.value);
        /**
        if (length != slider1.value)
        {
            room.SetLength(slider1.value);
            //Debug.Log(length);
        }
        if (width != slider2.value)
        {
            room.SetWidth(slider2.value);
            //width = slider2.value;
            //Debug.Log(width);
        }
        if (height != slider3.value)
        {
            room.SetHeight(slider3.value);
            //height = slider3.value;
            //Debug.Log(height);
        }
        **/
    }
}
