using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableData : MonoBehaviour
{
    public static bool reset = false;
    // Maps names to TransformData. 
    //private static Dictionary<int, Transform> transforms =
    //    new Dictionary<int, Transform>();
    private static Dictionary<string, Vector3> positions =
        new Dictionary<string, Vector3>();
    private static Dictionary<string, Quaternion> rotations =
        new Dictionary<string, Quaternion>();
    private static Dictionary<string, Vector3> localScales =
        new Dictionary<string, Vector3>();
    private float throttle = 0.0f;
    private float throttleCounter = 0.0f;
    public GameObject[] furnitureList;

    /**
    void Start()
    {
        SaveData();
    }
    **/
    
    public void SaveData()
    {
        // Getting the right positions before scene start.
        furnitureList = GameObject.FindGameObjectsWithTag("Interactable");
        // Provide the correct transform data IF reset == false;
        if (!reset)
        {
            foreach (GameObject item in furnitureList)
            {
                var itemName = item.name;
                //Debug.Log("Item Name:" + item.name);
                if (!positions.ContainsKey(itemName))
                {
                    positions[itemName] = item.transform.position;
                    rotations[itemName] = item.transform.rotation;
                    localScales[itemName] = item.transform.localScale;
                }
                // Update object's transform.
                item.transform.position = positions[itemName];
                item.transform.rotation = rotations[itemName];
                item.transform.localScale = localScales[itemName];
            }
        }
        else
        {
            positions.Clear();
            rotations.Clear();
            localScales.Clear();
            reset = false;
        }
    }

    void Update()
    {
        throttleCounter += Time.deltaTime;
        if (throttleCounter >= throttle)
        {
            foreach (GameObject item in furnitureList)
            {
                var itemName = item.name;
                positions[itemName] = item.transform.position;
                rotations[itemName] = item.transform.rotation;
                localScales[itemName] = item.transform.localScale;
            }
            //Debug.Log("Updated Transforms");
            throttle = 0.1f;
            throttleCounter = 0.0f;
        }
    }
}
