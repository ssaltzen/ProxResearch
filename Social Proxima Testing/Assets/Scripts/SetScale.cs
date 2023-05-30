using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    // Lengths:
    // For Left and Right Wall, change X Axis.
    // For Front and Back Wall, change Z Axis. 

    // Start is called before the first frame update
    // Use for reference of walls!
    [SerializeField] public GameObject roomCube; 

    void Awake()
    {
        //Temporary Manual Control over the room dimensions!
        float roomLength = RoomSpecs.length;
        float roomWidth = RoomSpecs.width;

        // Set default minimum
        if (roomLength < 9)
        {
            roomLength = 9.0f;
        }
        if (roomWidth < 9)
        {
            roomWidth = 9.0f;
        }

        // Length and width is in a scale from 9 to 30. 21 total sizes possible.
        roomLength = roomLength - 9;
        roomWidth = roomWidth - 9;

        float ratioOfLengthChange = roomLength / 21.0f;
        float ratioOfWidthChange = roomLength / 21.0f;

        // Scale can at max double the size of the room (scale of a 1 to 2 multiplier for size).
        // If length selected is 9, scale is multiplied be factor of 0 + 1 = 1.
        // If length is 30, scale multiplication factor is 1 + 1 = 2.
        float lengthSizeMultFactor = ratioOfLengthChange + 1;
        float widthSizeMultFactor = ratioOfLengthChange + 1;

        // Change Wall Size
        roomCube.transform.localScale = new Vector3(
            roomCube.transform.localScale.x * lengthSizeMultFactor, 
            roomCube.transform.localScale.y, 
            roomCube.transform.localScale.z);

        roomCube.transform.localScale = new Vector3(
            roomCube.transform.localScale.x, 
            roomCube.transform.localScale.y, 
            roomCube.transform.localScale.z * widthSizeMultFactor);
    }
}
