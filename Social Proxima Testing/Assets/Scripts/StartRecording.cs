using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRecording : MonoBehaviour
{

    [SerializeField] private GameObject recordIndicator;
    [SerializeField] private GameObject hitXToRecordIndicator;
    [SerializeField] private GameObject useEtoMoveFurniture;

    private float time = 10.0f;
    private float count = 0.0f;
    private bool countIsActive = false;

    public bool collectData { get; set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.pickUp == true)
        {
            hitXToRecordIndicator.SetActive(false);
            recordIndicator.SetActive(false);
            useEtoMoveFurniture.SetActive(true);
        }
        else
        {
            useEtoMoveFurniture.SetActive(false);
            if (collectData == true)
            {
                if (count <= time)
                {
                    if (countIsActive == false)
                    {
                        hitXToRecordIndicator.SetActive(false);
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
                    hitXToRecordIndicator.SetActive(true);
                }
            }
            else
            {
                hitXToRecordIndicator.SetActive(true);
            }
        }
    }
}
