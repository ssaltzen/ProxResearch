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
        //private MouseLock mouseLock;
        
        [SerializeField] private float playerSpeed = 10.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -15.00f;

        private Vector2 moveDirection;
        private Transform cameraTransform;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            objectPickup = gameObject.GetComponent<ObjectPickup>();
            //mouseLock = gameObject.GetComponent<MouseLock>();
            cameraTransform = FindObjectOfType<Camera>().gameObject.transform;
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
            animator.SetBool("Jump", !controller.isGrounded);

            // The ternary operator is for backwards diagonal movement.
            animator.SetFloat("Horizontal", moveDirection.x * (moveDirection.y >= 0 ? 1 : -1));
            animator.SetFloat("Vertical", moveDirection.y);

            animator.SetBool("Moving", (moveDirection.magnitude > 0));
        }

        // From Player Input component.
        private void OnMove(InputValue value)
        {
            moveDirection = value.Get<Vector2>();
        }

        // From Player Input component.
        private void OnJump()
        {
            if (groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }

        private void OnFire()
        {
            animator.SetTrigger("Social");
        }

        private void OnPause()
        {
            //mouseLock.UpdateMouseState();
            /* var index = SceneManager.GetActiveScene().buildIndex + 1;
            index %= 2; */
            SceneManager.LoadScene(0);
        }

        private void OnGrab()
        {
            objectPickup.PickupCheck();
        }
    }
}