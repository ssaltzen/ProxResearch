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
}
