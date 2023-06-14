using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceTracker : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerHead;
    [SerializeField] private GameObject npc;
    [SerializeField] private TMPro.TextMeshProUGUI distanceLog;
    [SerializeField] private TMPro.TextMeshProUGUI angleLog;

    private StartRecording dataManager;

    private float time;
    private float count = 0.0f;
    
    void Start()
    {
        dataManager = gameObject.GetComponent<StartRecording>();
    }

    // Data items we want from this tracker:
    //      Horizontal distance from the player to the couch
    //      The angle of the player and the couch

    // Update is called once per frame
    void Update()
    {
        if (dataManager.collectData == true)
        {
            // Show the distance from the NPC.
            var npcDistance = Vector3.Distance(player.transform.position, npc.transform.position);
            distanceLog.text = $"Distance from NPC: {npcDistance}";

            // The angle is specifically from the player's head to the couch (NPC) to represent a line-of-sight angle.
            // The exact angle calculations could probably use work. Tinker to find what you need!
            Vector3 toVector = playerHead.transform.position - npc.transform.position;
            float npcAngle = Vector3.Angle(transform.up, toVector);
            angleLog.text = $"Angle from NPC: {npcAngle}";

            // Count time since button press
            count += Time.deltaTime;
        }
    }
}
