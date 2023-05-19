using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureList : MonoBehaviour
{
    // Temporary (??) solution to getting all furniture items
    [SerializeField] private GameObject table;


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
        //      Set items to actual list we want
        SetInstantiableItems();

    }

    private void SetInstantiableItems()
    {
        // TODO: Eventually add something from menu setting only furniture items selected
        //      to be in instantiateFurnitureList
        foreach (var item in furnitureList)
        {
            instantiateFurnitureList.Add(item);
        }
        
    }

    public List<GameObject> GetFurnitureList()
    {
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
