using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDistanceTracker : MonoBehaviour
{

    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerHead;
    [SerializeField] public GameObject couch;
    
    private bool isTracking = true;

    private float timer = 0.0f;
    
    private float timerMax = 0.1f; //every 1/10 of a second

    private string filePath = "Assets/Data/";
    private StreamWriter writer;

    private const string OpenCountKey = "OpenCount";

    private StartRecording dataManager;

    private float time;
    private float count = 0.0f;
    
    void Start()
    {
        dataManager = gameObject.GetComponent<StartRecording>();
    }

    // Data items we want from this tracker:
    //      Horizontal distance from the player to the couch
    //      The angle of the player and the couch

    // Should be outputting to .json file


    // Start is called before the first frame update
    void Start()
    {
        // Display the open count from PlayerPrefs
        int openCount = PlayerPrefs.GetInt(OpenCountKey, 0);


        filePath = filePath + "playertracker" + openCount.ToString() + ".json";
        writer = File.AppendText(filePath);
        openCount++;
        PlayerPrefs.SetInt(OpenCountKey, openCount);
        
        
    }

    void OnDestroy()
    {
        writer.Close();
        writer.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        // when x is pressed, stop tracking or start tracking
        if (Input.GetKeyDown(KeyCode.X))
        {
            isTracking = !isTracking;
        }

        timer += Time.deltaTime;
        // track every 1/10 of a second.
        if (timer > timerMax)
        {
            var npcDistance = Vector3.Distance(player.transform.position, couch.transform.position);

            // The angle is specifically from the player's head to the couch (NPC) to represent a line-of-sight angle.
            // The exact angle calculations could probably use work. Tinker to find what you need!
            Vector3 toVector = playerHead.transform.position - npc.transform.position;
            float ncpAngle = Vector3.Angle(transform.up, toVector);

            float time = Time.time;
            
            PlayerDistanceData data = new PlayerDistanceData(npcDistance, ncpAngle, time, player.transform.position);
            string json = JsonUtility.ToJson(data);
            writer.WriteLine(json);
            writer.Flush();

            timer = 0.0f;
        }
    }

    [System.Serializable]
    public class PlayerDistanceData
    {
        public float distance;
        public float angle;
        public Vector3 location;
        public float time;

        public PlayerDistanceData(float distance, float angle, float time, Vector3 location)
        {
            this.distance = distance;
            this.angle = angle;
            this.time = time;
            this.location = location;
        }
    }
}
