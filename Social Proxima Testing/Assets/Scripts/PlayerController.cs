using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Proxemics
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private ObjectPickup objectPickup;
        private StartRecording dataManager;
        private EmoteMenu emoteMenu;
        //private MouseLock mouseLock;
        
        [SerializeField] private float playerSpeed = 10.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -15.00f;

        private Vector2 moveDirection;
        private Transform cameraTransform;

        private PlayerControls playerControls;
        private InputAction moveAction;
        private InputAction lookAction;
        private InputAction fireAction;
        private InputAction jumpAction;
        private InputAction pauseAction;
        private InputAction grabAction;
        private InputAction recordAction;

        private void Awake()
        {
            controller = gameObject.GetComponent<CharacterController>();
            objectPickup = gameObject.GetComponent<ObjectPickup>();
            // mouseLock = gameObject.GetComponent<MouseLock>();
            cameraTransform = FindObjectOfType<Camera>().gameObject.transform;
            dataManager = gameObject.GetComponent<StartRecording>();
            emoteMenu = FindObjectOfType<EmoteMenu>();
            playerControls = new PlayerControls();
        }
        
        private void OnEnable()
        {
            // All movement binds.
            moveAction = playerControls.Player.Move;
            lookAction = playerControls.Player.Look;

            // All unique action binds.
            fireAction = playerControls.Player.Fire;
            fireAction.performed += Fire;
            jumpAction = playerControls.Player.Jump;
            jumpAction.performed += Jump;
            pauseAction = playerControls.Player.Pause;
            pauseAction.performed += Pause;
            grabAction = playerControls.Player.Grab;
            grabAction.performed += Grab;
            recordAction = playerControls.Player.Record;
            recordAction.performed += Record;

            // Enable all commands selectively.
            moveAction.Enable();
            lookAction.Enable();
            fireAction.Enable();
            jumpAction.Enable();
            pauseAction.Enable();
            if (MainMenu.pickUp)
            {
                grabAction.Enable();
            }
            else
            {
                recordAction.Enable();
            }
        }

        private void OnDisable() 
        {
            // Simply disable all of the previously bound binds.
            moveAction.Disable();
            lookAction.Disable();
            fireAction.Disable();
            jumpAction.Disable();
            pauseAction.Disable();
            grabAction.Disable();
            recordAction.Disable();
        }

        private void FixedUpdate()
        {
            Move();
            Animate();
        }

        private void Update()
        {
            moveDirection = moveAction.ReadValue<Vector2>();
        }

        private void Move()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            // Pretty much stolen from CharacterController Move documentation.
            Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);

            // So player moves in direction of the camera.
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            // Rotate model based on where the player is looking.
            transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);
        }

        private void Animate()
        {
            animator.SetBool("Grounded", controller.isGrounded);

            // The ternary operator is for backwards diagonal movement.
            animator.SetFloat("Horizontal", moveDirection.x * (moveDirection.y >= 0 ? 1 : -1));
            animator.SetFloat("Vertical", moveDirection.y);

            animator.SetBool("Moving", (moveDirection.magnitude > 0));
        }

        // From Player Input component.
        private void Jump(InputAction.CallbackContext context)
        {
            if (groundedPlayer && context.ReadValueAsButton())
            {
                animator.SetTrigger("Jump");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -0.75f * gravityValue);
            }
        }

        private void Fire(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                emoteMenu.Open();
            }
            else if (!context.ReadValueAsButton())
            {
                emoteMenu.Close();
            }
        }

        private void Pause(InputAction.CallbackContext context)
        {
            // mouseLock.UpdateMouseState();
            /* var index = SceneManager.GetActiveScene().buildIndex + 1;
            index %= 2; */
            SceneManager.LoadScene(0);
        }

        private void Grab(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                //Debug.Log("test");
                objectPickup.PickupCheck();
            } 
        }

        private void Record(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                dataManager.collectData = true;
            }
        }
    }
}