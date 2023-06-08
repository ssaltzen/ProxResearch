using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableData : MonoBehaviour
{
    //[SerializeField] public GameObject participant;
    public static bool reset = false;
    private List<GameObject> furniture;
    private FurnitureList furnitureComponent;
    private float throttle = 0.0f;
    private float throttleCounter = 0.0f;

    // ID to GameObject.
    private static Dictionary<int, GameObject> ids =
        new Dictionary<int, GameObject>();
    // ID to TransformData. 
    private static Dictionary<int, Transform> transforms = 
        new Dictionary<int, Transform>();
    private static Dictionary<int, Vector3> positions =
        new Dictionary<int, Vector3>();
    private static Dictionary<int, Quaternion> rotations =
        new Dictionary<int, Quaternion>();
    private static Dictionary<int, Vector3> localScales =
        new Dictionary<int, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        if (!reset)
        {
            furnitureComponent = GetComponent<FurnitureList>();
            furniture = furnitureComponent.GetFurnitureList();
            Debug.Log("FurnitureCount: " + furniture.Count);
            for (int i = 0; i < furniture.Count; i++)
            {
                var id = furniture[i].GetInstanceID();
                Debug.Log(id);
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
            //transforms = new Dictionary<int, List<Vector3>>();
            //positions = new Dictionary<int, Vector3>();
            //rotations = new Dictionary<int, Quarternion>();
            //localScales = new Dictionary<int, Vector3>();
            reset = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For key, value in ids
        throttleCounter += Time.deltaTime;
        if (throttleCounter >= throttle)
        {
            foreach (KeyValuePair<int, GameObject> kvp in ids)
            {
                positions[kvp.Key] = kvp.Value.transform.position;
                rotations[kvp.Key] = kvp.Value.transform.rotation;
                localScales[kvp.Key] = kvp.Value.transform.localScale;
            }
            throttle = 0.1f;
            throttleCounter = 0.0f;
        }
    }
}
