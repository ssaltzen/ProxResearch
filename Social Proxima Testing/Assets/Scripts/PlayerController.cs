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
        private MouseLock mouseLock;
        private StartRecording dataManager;
        private EmoteMenu emoteMenu;

        [SerializeField] private float playerSpeed = 4.0f;
        [SerializeField] private float jumpHeight = 4.0f;
        [SerializeField] private float gravityValue = -15.00f;

        public Vector2 moveDirection { get; private set; }
        private Transform cameraTransform;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            objectPickup = gameObject.GetComponent<ObjectPickup>();
            mouseLock = gameObject.GetComponent<MouseLock>();
            cameraTransform = FindObjectOfType<Camera>().gameObject.transform;
            dataManager = gameObject.GetComponent<StartRecording>();
            emoteMenu = FindObjectOfType<EmoteMenu>();
        }

        private void Update()
        {
            Move();
            Animate();
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
        private void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }

        // From Player Input component.
        private void OnJump(InputAction.CallbackContext context)
        {
            if (groundedPlayer && context.started)
            {
                animator.SetTrigger("Jump");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -0.75f * gravityValue);
            }
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                emoteMenu.Open();
            }
            else if (context.canceled)
            {
                emoteMenu.Close();
            }
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            mouseLock.UpdateMouseState();
            /* var index = SceneManager.GetActiveScene().buildIndex + 1;
            index %= 2; */
            SceneManager.LoadScene(0);
        }

        private void OnGrab(InputAction.CallbackContext context)
        {
            objectPickup.PickupCheck();
        }
    }
}