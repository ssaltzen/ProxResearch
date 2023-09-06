using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectButtons : MonoBehaviour
{
    private Proxemics.PlayerControls playerControls;
    private StartRecording dataManager;

    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction jumpAction;

    private Vector2 moveDirection;

    void Awake()
    {
        dataManager = gameObject.GetComponent<StartRecording>();
        playerControls = new Proxemics.PlayerControls();
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

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();

        if (dataManager.collectData == true)
        {
            // Since this component is connected to the recording script,
            // we simply operate if recording is active.
            if ((moveDirection.x > 0) || (moveDirection.y > 0))
            {
                Debug.Log($"Player movement: X {moveDirection.x} | Y {moveDirection.y}");
            }
            if (jumpAction.triggered)
            {
                Debug.Log("Jump pressed");
            }
            if (fireAction.triggered)
            {
                Debug.Log("Fire pressed");
            }
        }
    }
}
