using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI tmproText;

    private void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            tmproText.text = v.ToString("0");
        });
    }
}