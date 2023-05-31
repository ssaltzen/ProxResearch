using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Switch : MonoBehaviour
{
    public Image onImage;
    public Image offImage;
    [SerializeField] private bool state;
    //public GameObject stats;
    // Start is called before the first frame update
    void Start()
    {
        //state = false
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ON()
    {
        //Off.gameObject.SetActive(true);
        //On.gameObject.SetActive(false);
        onImage.gameObject.SetActive(true);
        offImage.gameObject.SetActive(false);
        state = false;
    }

    public void OFF()
    {
        //Off.gameObject.SetActive(false);
        //On.gameObject.SetActive(true);
        onImage.gameObject.SetActive(false);
        offImage.gameObject.SetActive(true);
        state = true;
    }
}
