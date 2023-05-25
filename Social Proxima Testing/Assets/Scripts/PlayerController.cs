using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Proxemics
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private GameObject gameController;
        
        [SerializeField] private float playerSpeed = 10.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -15.00f;

        private Vector2 moveDirection;
        private Transform cameraTransform;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            cameraTransform = FindObjectOfType<Camera>().gameObject.transform;
            gameController = GameObject.Find("GameController");
        }

        private void Update()
        {
            MoveUpdate();
        }

        private void MoveUpdate()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            // Pretty much stolen from CharacterController Move documention.
            Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
            // So player moves in direction of the camera.
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
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
            gameController.GetComponent<SpawnFurniture>().CreateFurniture();
        }

        private void OnPause()
        {
            var index = SceneManager.GetActiveScene().buildIndex + 1;
            index %= 2;
            SceneManager.LoadScene(index);
        }
    }
}