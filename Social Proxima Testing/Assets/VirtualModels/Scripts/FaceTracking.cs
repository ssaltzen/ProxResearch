using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes virtual model look at the player within a certain range
public class FaceTracking : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 90f)]
    private float maxHorizontalNeckTurn;

    [SerializeField]
    [Range(0f, 90f)]
    private float maxVerticalNeckTurn;


    [SerializeField]
    private Transform neckBone;
    private Transform headBone;

    [SerializeField]
    private Transform objectTracking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float GetAngleTowardsTarget()
    {
        return 0f;
    }

}
