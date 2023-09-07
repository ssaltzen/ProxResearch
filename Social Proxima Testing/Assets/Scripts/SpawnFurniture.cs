using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFurniture : MonoBehaviour
{
    private float throttle = 0.0f;
    private float throttleCounter = 0.0f;
    private List<GameObject> furniture;
    private FurnitureList furnitureComponent;
    private bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        furniture = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Throttle the spawn rate of furniture item
        throttleCounter += Time.deltaTime;
        
        furnitureComponent = GetComponent<FurnitureList>();
        furniture = furnitureComponent.GetFurnitureList();
        //Debug.Log("Furniture available... " + furniture);
        if (throttleCounter >= throttle)
        {
            
            if (furniture.Count != 0)
            {
                Instantiate(furniture[0]);
                furniture.RemoveAt(0);
                furnitureComponent.SetFurnitureList(furniture);
                furniture = furnitureComponent.GetFurnitureList();
            }
            else if ((furniture.Count == 0) && !moved)
            {
                // When nothing is left, move the furniture to their corresponding positions.
                GetComponent<InteractableData>().SaveData();
                moved = true;
            }
            throttle = 0.1f;
            throttleCounter = 0.0f;
        }
    }
}
