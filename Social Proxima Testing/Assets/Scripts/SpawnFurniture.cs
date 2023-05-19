using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFurniture : MonoBehaviour
{
    private float throttle = 0.0f;
    private float throttleCounter = 0.0f;
    private List<GameObject> furniture;
    // Start is called before the first frame update
    void Start()
    {
        furniture = new List<GameObject>();
        furniture = GetComponent<FurnitureList>().GetFurnitureList();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Throttle the spawn rate of furniture item
        throttleCounter += Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (throttleCounter >= throttle)
            {
                //Debug.Log("Spawning... " + furniture);
                if (furniture.Count != 0)
                {
                    Debug.Log("Spawning... " + furniture);
                    Instantiate(furniture[0]);
                    throttle = 3.0f;
                    throttleCounter = 0.0f;
                }
            }
        }
    }
}
