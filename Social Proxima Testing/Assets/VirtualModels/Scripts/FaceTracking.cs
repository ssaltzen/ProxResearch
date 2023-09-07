using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

// Makes virtual model look at the player within a certain range
public class FaceTracking : MonoBehaviour
{
    private const float followSpeed = 3.0f;

    [SerializeField]
    [Min(0f)]
    private float maxTrackDistance;

    [SerializeField]
    private Transform objectTracking;

    [SerializeField]
    private Transform ikTarget;
    private Vector3 defaultIKPos;

    private Rig rig;

    private void Awake()
    {
        defaultIKPos = ikTarget.localPosition;
        rig = GetComponentInChildren<Rig>();
    }

    private void Update()
    {
        // Look straight if there is nothing to look at
        if (!objectTracking)
        {
            ikTarget.localPosition = defaultIKPos;
            UpdateTrackingGradient(false);
            return;
        }

        // Update look target position
        ikTarget.position = objectTracking.position;

        // Don't follow if the object is too far away
        if ( Vector2.Distance(objectTracking.transform.position, transform.position) > maxTrackDistance)
        {
            UpdateTrackingGradient(false);
            return;
        }

        UpdateTrackingGradient(true);
    }

    // Updates tracking gradient based on whether the target can be focused on or not
    private void UpdateTrackingGradient(bool isTracking)
    {
        if (isTracking)
        {
            rig.weight = Mathf.Min(rig.weight + Time.deltaTime * followSpeed, 1);
        }
        else
        {
            rig.weight = Mathf.Max(rig.weight - Time.deltaTime * followSpeed, 0);
        }
    }

    public void SetObjectTracking(Transform objectTracking)
    {
        this.objectTracking = objectTracking;
    }

}
