using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject characterMenu;
    [SerializeField] private GameObject mainFurnitureMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        characterMenu.SetActive(false);
        mainFurnitureMenu.SetActive(false);
    }
}
