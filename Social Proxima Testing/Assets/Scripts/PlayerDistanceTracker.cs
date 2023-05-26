using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceTracker : MonoBehaviour
{

    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerHead;
    [SerializeField] public GameObject couch;

    // Theoretically, the player will be interacting with a second model which will be sitting on the couch.
    // So the couch for now is acting as distance from "player 2," which is important to highlight 
    //      (can be replaced later with NPC object).
    // Furniture locations need to be done after implementing final positions/movement capabilities!

    // Data items we want from this tracker:
    //      Horizontal distance from the player to the couch
    //      The angle of the player and the couch

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            var npcDistance = Vector3.Distance(player.transform.position, couch.transform.position);
            Debug.Log("Distance from NPC: " + npcDistance);

            // The angle is specifically from the player's head to the couch (NPC) to represent a line-of-sight angle
            // The exact angle calculations could probably use work. Tinker to find what you need!
            Vector3 toVector = playerHead.transform.position - couch.transform.position;
            float ncpAngle = Vector3.Angle(transform.up, toVector);
            Debug.Log("Angle from NPC: " + ncpAngle);
        }
    }
}
