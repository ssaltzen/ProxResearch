using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    NO LONGER IN USE!
    InteractableData.cs has the same functionality. 
    Differences:
    - No need for [SerializeField] items.
**/
public class FurnitureManager : MonoBehaviour
{
    [SerializeField] public GameObject couch;
    [SerializeField] public GameObject table;
    [SerializeField] public GameObject chair1;
    [SerializeField] public GameObject chair2;
    [SerializeField] public GameObject chair3;
    [SerializeField] public GameObject chair4;
    [SerializeField] public GameObject chair5;
    [SerializeField] public GameObject chair6;
    [SerializeField] public GameObject chair7;
    [SerializeField] public GameObject chair8;
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

    // Start is called before the first frame update
    void Start()
    {
        // Toggling furniture ON/OFF
        // Couch is always ON
        table.SetActive(FurnitureMenuValues.table);
        int chairCount = FurnitureMenuValues.numOfChairs;
        SetChairs(chairCount);

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

    public void SetChairs(int chairCount)
    {
        chair1.SetActive(false);
        chair2.SetActive(false);
        chair3.SetActive(false);
        chair4.SetActive(false);
        chair5.SetActive(false);
        chair6.SetActive(false);
        chair7.SetActive(false);
        chair8.SetActive(false);
        if (chairCount >= 1)
        {
            chair1.SetActive(true);
        }
        if (chairCount >= 2)
        {
            chair2.SetActive(true);
        }
        if (chairCount >= 3)
        {
            chair3.SetActive(true);
        }
        if (chairCount >= 4)
        {
            chair4.SetActive(true);
        }
        if (chairCount >= 5)
        {
            chair5.SetActive(true);
        }
        if (chairCount >= 6)
        {
            chair6.SetActive(true);
        }
        if (chairCount >= 7)
        {
            chair7.SetActive(true);
        }
        if (chairCount == 8)
        {
            chair8.SetActive(true);
        }
    }
}
