using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool pickUp = true;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject RoomOptionsMenu;
    [SerializeField] GameObject RoomOptionsPopUp;
    [SerializeField] GameObject PlayPopUp;

    
    public void Play() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        pickUp = false;
        //Debug.Log("Play");
    }

    public void MoveFurniture()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        pickUp = true;
        //Debug.Log("Move Furniture");
    }

    // In Options Menu
    public void MoveOptions()
    {
        OptionsMenu.SetActive(false);
        RoomOptionsMenu.SetActive(true);
    }

    // In Main Menu
    public void PlayAlert()
    {
        Play();
    }

    public void Quit()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }

    public void Reset()
    {
        // Essentially, we just reload the scene, so stats reset.
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        InteractableData.reset = true;
        FurnitureManager.reset = true;
        //Debug.Log("Reset");
    }
}
