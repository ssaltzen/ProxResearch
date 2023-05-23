using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    // For Left and Right Wall, change X Axis.
    // For Front and Back Wall, change Z Axis. 
    // Start is called before the first frame update
    [SerializeField] public GameObject leftWall;
    [SerializeField] public GameObject rightWall;
    [SerializeField] public GameObject frontWall;
    [SerializeField] public GameObject backWall;

    void Awake()
    {
        //leftWall.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z)
        Debug.Log(leftWall.transform.localScale.x);
        Debug.Log(RoomSpecs.length);
        float roomLength = RoomSpecs.length;
        float roomWidth = RoomSpecs.width;

        // Change Wall Size
        leftWall.transform.localScale = new Vector3((float)RoomSpecs.length*5, 
            leftWall.transform.localScale.y, leftWall.transform.localScale.z);
        rightWall.transform.localScale = new Vector3((float)RoomSpecs.length * 5,
            rightWall.transform.localScale.y, rightWall.transform.localScale.z);
        frontWall.transform.localScale = new Vector3(frontWall.transform.localScale.x,
            frontWall.transform.localScale.y, (float)RoomSpecs.width * 5);
        backWall.transform.localScale = new Vector3(backWall.transform.localScale.x,
            backWall.transform.localScale.y, (float)RoomSpecs.width * 5);

        // Change Positions of Walls Accordingly.
        leftWall.transform.position = new Vector3(leftWall.transform.position.x,
            leftWall.transform.position.y, roomLength);
        rightWall.transform.position = new Vector3(rightWall.transform.position.x,
            rightWall.transform.position.y, roomLength);
        frontWall.transform.position = new Vector3(roomWidth,
            frontWall.transform.position.y, frontWall.transform.position.z);
        backWall.transform.position = new Vector3(roomWidth,
            backWall.transform.position.y, backWall.transform.position.z);
    }
}
