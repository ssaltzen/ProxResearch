using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    // Lengths:
    // For Left and Right Wall, change X Axis.
    // For Front and Back Wall, change Z Axis. 

    // Start is called before the first frame update
    [SerializeField] public GameObject leftWall;
    [SerializeField] public GameObject rightWall;
    [SerializeField] public GameObject frontWall;
    [SerializeField] public GameObject backWall;
    // Use for reference of walls!
    [SerializeField] public GameObject center; 

    void Awake()
    {
        //leftWall.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z)
        Debug.Log(leftWall.transform.localScale.x);
        Debug.Log(RoomSpecs.length);
        float roomLength = RoomSpecs.length;
        float roomWidth = RoomSpecs.width;

        // Change Wall Size
        leftWall.transform.localScale = new Vector3(
            roomLength * 2, 
            leftWall.transform.localScale.y, 
            leftWall.transform.localScale.z);
        rightWall.transform.localScale = new Vector3(
            roomLength * 2,
            rightWall.transform.localScale.y, 
            rightWall.transform.localScale.z);
        frontWall.transform.localScale = new Vector3(
            roomWidth * 2,
            frontWall.transform.localScale.y,
            frontWall.transform.localScale.z);
        backWall.transform.localScale = new Vector3(
            roomWidth * 2,
            backWall.transform.localScale.y,
            backWall.transform.localScale.z);

        // Change Positions of Walls Accordingly.
        leftWall.transform.position = new Vector3(
            center.transform.position.x - roomLength,
            center.transform.position.y,
            center.transform.position.z);
        rightWall.transform.position = new Vector3(
            center.transform.position.x + roomLength,
            center.transform.position.y,
            center.transform.position.z);
        frontWall.transform.position = new Vector3(
            center.transform.position.x,
            center.transform.position.y,
            center.transform.position.z + roomWidth);
        backWall.transform.position = new Vector3(
            center.transform.position.x,
            center.transform.position.y,
            center.transform.position.z - roomWidth);
    }
}
