using UnityEngine;
using UnityEngine.InputSystem;

public class DataManager : MonoBehaviour
{
	private StartRecording recordingManager;

	// Required setup to read from player input.
	private Proxemics.PlayerControls playerControls;
	private InputAction moveAction;
    private InputAction fireAction;
    private InputAction jumpAction;
    private Vector2 moveDirection;
	
	// Required setup to calculate positional data.
	[SerializeField] private GameObject player;
    [SerializeField] private GameObject playerHead;
    [SerializeField] private GameObject npc;
	
	// Class for storing data.
	private class dataClass
	{
		public int currentFrame;
		public bool jumpFired;
		public bool emoteFired;
		public Vector2 movementDirection;
		public Vector2 touchPosition;
		public float distanceFrom;
		public float angleFrom;
	}

	// Create data class.
	private dataClass data = new dataClass();

	void Awake()
    {
        recordingManager = gameObject.GetComponent<StartRecording>();
        playerControls = new Proxemics.PlayerControls();
		Debug.Log(Application.persistentDataPath + "/output.json");
    }

    void OnEnable()
    {
        moveAction = playerControls.Player.Move;
        fireAction = playerControls.Player.Fire;
        jumpAction = playerControls.Player.Jump;
        moveAction.Enable();
        fireAction.Enable();
        jumpAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
        jumpAction.Disable();
    }

	// Stash data on this frame to the data class.
	void ReadData()
	{
		data.currentFrame = Time.frameCount;
		data.touchPosition = Touchscreen.current.position.ReadValue();
		data.jumpFired = jumpAction.triggered;
		data.emoteFired = fireAction.triggered;
		data.movementDirection = moveAction.ReadValue<Vector2>();
		data.distanceFrom = Vector3.Distance
			(player.transform.position, npc.transform.position);
		Vector3 toVector = playerHead.transform.position - npc.transform.position;
		data.angleFrom = Vector3.Angle(transform.up, toVector);
	}


	// Convert data classes to JSON, and add output to an external file.
	void Record()
	{
		// Convert data classes to JSON.
		var dataJSON = JsonUtility.ToJson(data);
		string filePath = Application.persistentDataPath + "/output.json";

		// If the output file does not already exist, create a new file.
		if (!System.IO.File.Exists(filePath))
		{
			System.IO.File.WriteAllText(filePath, dataJSON);
		}
		else
		{
			System.IO.File.AppendAllText(filePath, dataJSON);
		}
	}

	void Update()
	{
		// If recording, update data and then output it.
		if (recordingManager.collectData == true)
		{
			ReadData();
			Record();
		}
	}
}