using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // ID to GameObject.
    // Maybe store ID's as a tuple?
    // Is there a way to get the gameobject from the ID?
    private static Dictionary<int, GameObject> ids =
        new Dictionary<int, GameObject>();
    // ID to TransformData. 
    //private static Dictionary<int, Transform> transforms =
    //    new Dictionary<int, Transform>();
    private static Dictionary<int, Vector3> positions =
        new Dictionary<int, Vector3>();
    private static Dictionary<int, Quaternion> rotations =
        new Dictionary<int, Quaternion>();
    private static Dictionary<int, Vector3> localScales =
        new Dictionary<int, Vector3>();
    private float throttle = 0.0f;
    private float throttleCounter = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        // Toggling furniture ON/OFF
        // Couch is always ON
        table.SetActive(FurnitureMenuValues.table);
        int chairCount = FurnitureMenuValues.numOfChairs;
        SetChairs(chairCount);

        // Getting the right positions before scene start.
        List<GameObject> furniture = new List<GameObject>()
        {
            couch, table, chair1, chair2, chair3, 
            chair4, chair5, chair6, chair7, chair8
        };
        // Provide the correct transform data IF reset == false;
        if (!reset)
        {
            for (int i = 0; i < furniture.Count; i++)
            {
                var id = furniture[i].GetInstanceID();
                Debug.Log(furniture[i].name + ": " + id);
                Debug.Log("Real couch" + couch.GetInstanceID());
                if (!ids.ContainsKey(id))
                {
                    ids[id] = furniture[i];
                    // Store position in corresponding dictionaries.
                    positions[id] = furniture[i].transform.position;
                    rotations[id] = furniture[i].transform.rotation;
                    localScales[id] = furniture[i].transform.localScale;
                }
                // Update object's transform.
                ids[id].transform.position = positions[id];
                ids[id].transform.rotation = rotations[id];
                ids[id].transform.localScale = localScales[id];
            }
        }
        else
        {
            ids = new Dictionary<int, GameObject>();
            //transforms.Clear();
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
            foreach (KeyValuePair<int, GameObject> kvp in ids)
            {
                positions[kvp.Key] = kvp.Value.transform.position;
                rotations[kvp.Key] = kvp.Value.transform.rotation;
                localScales[kvp.Key] = kvp.Value.transform.localScale;
            }
            Debug.Log("Updated Transforms");
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
