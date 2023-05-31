using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureMenuValues : MonoBehaviour
{
    // Room Values from Sliders
    public static float length;
    public static float width;
    public static bool table = true;
    public static bool couch = true;
    public static int numOfChairs;

    // These are for changing the displays
    [SerializeField] public Slider lengthSlider;
    [SerializeField] private TextMeshProUGUI lengthText;
    [SerializeField] public Slider widthSlider;
    [SerializeField] private TextMeshProUGUI widthText;
    [SerializeField] public Slider chairSlider;
    [SerializeField] public Toggle tableToggle;
    [SerializeField] public Toggle couchToggle;


    void Awake()
    {
        lengthSlider.value = length;
        lengthText.text = length.ToString();
        widthSlider.value = width;
        widthText.text = width.ToString();
        tableToggle.isOn = table;
        couchToggle.isOn = couch;
        chairSlider.value = (int) numOfChairs;
    }

    void Start()
    {
        
    }

    void Update()
    {
        length = lengthSlider.value;
        width = widthSlider.value;
        table = tableToggle.isOn;
        couch = couchToggle.isOn;
        numOfChairs = (int) chairSlider.value;
    }
}
