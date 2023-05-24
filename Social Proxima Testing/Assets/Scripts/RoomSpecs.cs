using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSpecs : MonoBehaviour
{
    // Room Values from Sliders
    public static float length;
    public static float width;
    public static float height;
    // Furniture(On/Off)
    public static bool lamp;
    public static bool f2;
    public static bool f3;

    [SerializeField] public Slider lengthSlider;
    [SerializeField] public Slider widthSlider;
    [SerializeField] public Slider heightSlider;

    [SerializeField] public Button lampButton;
    //[SerializeField] public Button button2;
    //[SerializeField] public Button button3;

    void Awake()
    {
        length = lengthSlider.value;
        width = widthSlider.value;
        height = heightSlider.value;

        //lamp = lampButton.
        //Debug.Log(length);
    }

    // I think this is important for when you "pause" the Game.
    // I am hoping to save the room's specs when we pause. 
    void Start()
    {
        lengthSlider.value = length;
        widthSlider.value = width;
        heightSlider.value = height;
    }

    void Update()
    {
        //if (length != slider1.value)
        length = lengthSlider.value;
        width = widthSlider.value;
        height = heightSlider.value;
    }
}

