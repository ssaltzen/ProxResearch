using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureMenuValues : MonoBehaviour
{
    // Static Room Values from Sliders.
    public static float length = 9.0f;
    public static float width = 9.0f;
    public static bool table = true;
    public static bool couch = true;
    public static int numOfChairs = 0;
    public static float lightLevel = 4.0f;

    // These objects are for maintaining the display values between scenes.
    [SerializeField] public Slider lengthSlider;
    [SerializeField] private TextMeshProUGUI lengthText;
    [SerializeField] public Slider widthSlider;
    [SerializeField] private TextMeshProUGUI widthText;
    [SerializeField] public Slider chairSlider;
    [SerializeField] private TextMeshProUGUI chairsText;
    [SerializeField] public Toggle tableToggle;
    [SerializeField] public Slider lightSlider;
    [SerializeField] private TextMeshProUGUI lightTextValue;

    void Awake()
    {
        // Set Length Slider to prior value
        lengthSlider.value = length;
        lengthText.text = length.ToString();
        // Set Width Slider to prior value
        widthSlider.value = width;
        widthText.text = width.ToString();
        // Set Table Toggle to prior value
        tableToggle.isOn = table;
        // Set Chair Slider Value Toggle to prior value
        chairSlider.value = (int) numOfChairs;
        chairsText.text = numOfChairs.ToString();
        // Set Light Slider Value Toggle to prior value
        lightSlider.value = lightLevel;
        lightTextValue.text = lightLevel.ToString();
    }

    void Update()
    {
        length = lengthSlider.value;
        width = widthSlider.value;
        table = tableToggle.isOn;
        numOfChairs = (int) chairSlider.value;
        chairsText.text = numOfChairs.ToString();
        lightLevel = lightSlider.value;
    }

}
