using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRecording : MonoBehaviour
{

    [SerializeField] private GameObject recordIndicator;
    [SerializeField] private GameObject recordButton;
    [SerializeField] private GameObject furnitureButton;

    private float time = 10.0f;
    private float count = 0.0f;
    private bool countIsActive = false;

    public bool collectData { get; set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.pickUp == false)
        {
            furnitureButton.SetActive(false);
            recordButton.SetActive(true);
            
            if (collectData == true)
            {
                if (count <= time)
                {
                    if (countIsActive == false)
                    {
                        recordIndicator.SetActive(true);
                    }

                    // Count time since button press
                    count += Time.deltaTime;
                    // Set recording UI to active
                    collectData = true;
                    countIsActive = true;
                }

                else
                {
                    collectData = false;
                    countIsActive = false;
                    count = 0.0f;
                    recordIndicator.SetActive(false);
                }
            }
        }
        else
        {
            furnitureButton.SetActive(true);
            recordButton.SetActive(false);
        }
    }
}
