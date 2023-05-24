using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseToMain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            var index = SceneManager.GetActiveScene().buildIndex + 1;
            index %= 2;
            SceneManager.LoadScene(index);
        }
    }
}
