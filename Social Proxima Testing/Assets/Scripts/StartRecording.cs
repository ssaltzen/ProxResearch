using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRecording : MonoBehaviour
{

    [SerializeField] private GameObject recordIndicator;
    [SerializeField] private GameObject hitXToRecordIndicator;

    private float time = 10.0f;
    private float count = 0.0f;
    private bool collectData = false;
    private bool countIsActive = false;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.X)) || (collectData == true))
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
    }
}
