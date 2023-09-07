using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject characterMenu;
    [SerializeField] private GameObject mainFurnitureMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.gameHasBeenEntered == true)
        {
            mainMenu.SetActive(false);
            characterMenu.SetActive(false);
            mainFurnitureMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            characterMenu.SetActive(false);
            mainFurnitureMenu.SetActive(false);
        }
    }

    void Awake()
    {
        if (MainMenu.gameHasBeenEntered == true)
        {
            mainMenu.SetActive(false);
            characterMenu.SetActive(false);
            mainFurnitureMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            characterMenu.SetActive(false);
            mainFurnitureMenu.SetActive(false);
        }
    }
}
