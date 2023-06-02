using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes virtual model look at the player within a certain range
public class FaceTracking : MonoBehaviour
{
    private const float followSpeed = 3.0f;

    [SerializeField]
    [Range(0f, 90f)]
    private float maxHeadTurn;

    [SerializeField]
    [Min(0f)]
    private float maxTrackDistance;

    [SerializeField]
    private Transform headBone;

    [SerializeField]
    private Transform objectTracking;

    private float trackingGradient = 0f;                // For smooth transition from head position in animation
    private Vector3 lastRealDirection = Vector3.zero;   // Saves last direction set by script to transition back to animation when focus is lost


    void LateUpdate()
    {
        // Do nothing if there is no object or if the object is too far away
        if (!objectTracking || Vector3.Distance(objectTracking.transform.position, headBone.position) > maxTrackDistance)
        {
            ReturnHead();
            return;
        }
        
        Vector3 targetDirection = GetTargetHeadDirection();

        if (Vector3.Angle(headBone.forward, targetDirection) > maxHeadTurn)
        {
            ReturnHead();
            return;
        }

        UpdateTrackingGradient(true);

        Vector3 realHeadDirection = Vector3.Lerp(headBone.forward, targetDirection, trackingGradient);
        headBone.forward = realHeadDirection;

        lastRealDirection = realHeadDirection;
    }

    // Transitions from the last direction set by the script to the animation
    private void ReturnHead()
    {
        UpdateTrackingGradient(false);
        Vector3 realHeadDirection = Vector3.Lerp(headBone.forward, lastRealDirection, trackingGradient);
        headBone.forward = realHeadDirection;
    }

    // Updates tracking gradient based on whether the target can be focused on or not
    private void UpdateTrackingGradient(bool isTracking)
    {
        if (isTracking)
        {
            trackingGradient = Mathf.Min(trackingGradient + Time.deltaTime * followSpeed, 1);
        }
        else
        {
            trackingGradient = Mathf.Max(trackingGradient - Time.deltaTime * followSpeed, 0);
        }
    }

    // Gets direction required to look at tracking object
    private Vector3 GetTargetHeadDirection()
    {
        Vector3 pos = headBone.position;
        Vector3 targetPos = objectTracking.position;
        Vector3 difference = targetPos - pos;
        return Vector3.Normalize(difference);
    }

}
