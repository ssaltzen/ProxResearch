using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureList : MonoBehaviour
{
    // Temporary (??) solution to getting all furniture items
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject chair1;
    [SerializeField] private GameObject chair2;
    [SerializeField] private GameObject chair3;
    [SerializeField] private GameObject chair4;
    [SerializeField] private GameObject chair5;
    [SerializeField] private GameObject chair6;
    [SerializeField] private GameObject chair7;
    [SerializeField] private GameObject chair8;
    //[SerializeField] private GameObject sofa;


    // Total List of furniture items (???)
    private List<GameObject> furnitureList;
    // List of items to be instantiated upon opening the game (??)
    private List<GameObject> instantiateFurnitureList;

    void Start()
    {
        furnitureList = new List<GameObject>();
        instantiateFurnitureList = new List<GameObject>();

        // VERY temporary solution (this is clunky)
        //      Manually add each furniture object available to the list in Start:
         
        furnitureList.Add(table);
        furnitureList.Add(chair1);
        furnitureList.Add(chair2);
        furnitureList.Add(chair3);
        furnitureList.Add(chair4);
        furnitureList.Add(chair5);
        furnitureList.Add(chair6);
        furnitureList.Add(chair7);
        furnitureList.Add(chair8);
        //furnitureList.Add(lamp);
        //furnitureList.Add(sofa);
        //      Set items to actual list we want

        // TODO: Need to find how to call this at end of Main Menu Scene
        SetInstantiableItems();

    }

    public void SetInstantiableItems()
    {
        // TODO: Eventually add something from menu setting only furniture items selected
        //      to be in instantiateFurnitureList

        // Temporary Controls over the number and type of furniture that spawns in...
        bool isTableSpawned = true;//GetComponent<RoomSpecs>().GetIfTableSpawns();
        int numOfChairs = 8;//GetComponent<RoomSpecs>().GetNumOfChairs();

        // Choose to spawn in table or not.
        if (isTableSpawned == false)
        {
            furnitureList.RemoveAt(0);
        }
        else
        {
            this.instantiateFurnitureList.Add(furnitureList[0]);
            furnitureList.RemoveAt(0);
        }

        // Add in correct number of chairs
        for (var i = 0; i < numOfChairs; i++)
        {
            Debug.Log(i + ": " + furnitureList[i]);
            this.instantiateFurnitureList.Add(furnitureList[i]);
        }
        
    }

    public List<GameObject> GetFurnitureList()
    {
        Debug.Log(this.instantiateFurnitureList);
        return instantiateFurnitureList;
    }

    public void SetFurnitureList(List<GameObject> newList)
    {
        this.instantiateFurnitureList = newList;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.instantiateFurnitureList);
    }
}
