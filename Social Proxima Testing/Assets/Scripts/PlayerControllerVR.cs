using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Proxemics
{
    public class PlayerControllerVR : MonoBehaviour
    {
        private ObjectPickup objectPickup;
        private EmoteMenu emoteMenu;

        // Start is called before the first frame update
        void Start()
        {
            objectPickup = gameObject.GetComponent<ObjectPickup>();
            emoteMenu = FindObjectOfType<EmoteMenu>();
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
