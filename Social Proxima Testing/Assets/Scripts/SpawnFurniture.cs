using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFurniture : MonoBehaviour
{
    private float throttle = 0.0f;
    private float throttleCounter = 0.0f;
    private List<GameObject> furniture;
    private FurnitureList furnitureComponent;
    // Start is called before the first frame update
    void Start()
    {
        furniture = new List<GameObject>();
        //furnitureComponent = GetComponent<FurnitureList>();
        //furniture = furnitureComponent.GetFurnitureList();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Throttle the spawn rate of furniture item
        throttleCounter += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            furnitureComponent = GetComponent<FurnitureList>();
            furniture = furnitureComponent.GetFurnitureList();
            Debug.Log("Furniture available... " + furniture);
            if (throttleCounter >= throttle)
            {
                
                if (furniture.Count != 0)
                {
                    Debug.Log("Spawning... " + furniture);
                    Instantiate(furniture[0]);
                    furniture.RemoveAt(0);
                    furnitureComponent.SetFurnitureList(furniture);
                    furniture = furnitureComponent.GetFurnitureList();
                }
                else
                {
                    Debug.Log("No Furniture Left to Spawn in List!");
                }
                throttle = 0.5f;
                throttleCounter = 0.0f;
            }
        }
    }
}
