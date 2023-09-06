using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProBuilder;
using UnityEngine;
using UnityEngine.ProBuilder;

public class SetVRFloorScale : MonoBehaviour
{
    [SerializeField] private GameObject roomCube;
    [SerializeField] private GameObject vrFloor;

    private void Awake()
    { 
        //float roomLength = FurnitureMenuValues.length;
        //float roomWidth = FurnitureMenuValues.length;

        var cubeSize = roomCube.GetComponent<Renderer>().bounds.size;
        
        // Set default minimum
        if (cubeSize.x < 9)
        {
            cubeSize.x = 9.0f;
        }
        if (cubeSize.z < 9)
        {
            cubeSize.z = 9.0f;
        }

        // Update size of VR floor to match the room.
        var newFloorPosition = vrFloor.transform.position;
        newFloorPosition.x = roomCube.transform.position.x + (cubeSize.x / 2);
        newFloorPosition.z = roomCube.transform.position.z + (cubeSize.z / 2);
        vrFloor.transform.position = newFloorPosition;

        var newFloorScale = vrFloor.transform.localScale;
        newFloorScale.x = cubeSize.x / 10;
        newFloorScale.z = cubeSize.z / 10;
        vrFloor.transform.localScale = newFloorScale;
    }
}
