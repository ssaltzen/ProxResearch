using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VirtualModelLoader : MonoBehaviour
{
    // Start is called before the first frame update

    public static int modelType = 0;
    private string modelTypeText = "Male";
    [SerializeField] public Slider modelSlider;
    [SerializeField] private TextMeshProUGUI modelText;
    

    void Awake()
    {
        modelType = (int) modelSlider.value;
        modelText.text = modelTypeText;
    }

    void Start()
    {
        modelType = (int) modelSlider.value;
        modelText.text = modelTypeText;
    }

    // Update is called once per frame
    void Update()
    {
        modelType = (int) modelSlider.value;
        if (modelType == 0)
        {
            modelTypeText = "Male";
        }
        if (modelType == 1)
        {
            modelTypeText = "Female";
        }
        if (modelType == 2)
        {
            modelTypeText = "Non-Binary";
        }
        if (modelType == 3)
        {
            modelTypeText = "Non-Humanoid";
        }
        modelText.text = modelTypeText;
    }
}
