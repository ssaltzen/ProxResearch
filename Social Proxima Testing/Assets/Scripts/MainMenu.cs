using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() {
        //var roomSpecs = GetComponent<RoomSpecs>();
        //Debug.Log(roomSpecs);
        //var roomLength = roomSpecs.GetCurrentLength();
        //var roomWidth = roomSpecs.GetCurrentWidth();
        //var numOfChairs = roomSpecs.GetNumOfChairs();
        //var doesTableSpawn = roomSpecs.GetIfTableSpawns();
        //Debug.Log("Final num of chairs: " + numOfChairs);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Play");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
