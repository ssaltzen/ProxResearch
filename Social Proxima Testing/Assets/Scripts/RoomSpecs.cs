using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSpecs : MonoBehaviour
{
    // Room Values from Sliders
    public static float length;
    public static float width;
    public static int numOfChairs;
    // Furniture(On/Off)
    public static bool table = true;
    //public static bool f2;
    //public static bool f3;

    [SerializeField] public Slider lengthSlider;
    [SerializeField] public Slider widthSlider;
    [SerializeField] public Slider chairSlider;

    [SerializeField] public Toggle tableButton;
    //[SerializeField] public Button button2;
    //[SerializeField] public Button button3;

    void Awake()
    {
        length = lengthSlider.value;
        width = widthSlider.value;
        numOfChairs = (int) chairSlider.value;

        //lamp = lampButton.
        //Debug.Log(length);
    }

    // I think this is important for when you "pause" the Game.
    // I am hoping to save the room's specs when we pause. 
    void Start()
    {
        lengthSlider.value = length;
        widthSlider.value = width;
        chairSlider.value = numOfChairs;
    }

    void Update()
    {
        //if (length != slider1.value)
        length = lengthSlider.value;
        width = widthSlider.value;
        numOfChairs = (int) chairSlider.value;
        Debug.Log(numOfChairs);
    }

    public float GetCurrentLength()
    {
        return length;
    }

    public float GetCurrentWidth()
    {
        return width;
    }

    public int GetNumOfChairs()
    {
        return 8;
    }

    public bool GetIfTableSpawns()
    {
        return true;
    }

}

