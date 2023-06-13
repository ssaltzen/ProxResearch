using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    private GameObject pickedObject;
    private Transform originalParent;

    private void PickupObject()
    {
        // Perform a raycast to detect an interactable object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Debug.Log("Hit");
                // Store a reference to the picked object
                pickedObject = hit.collider.gameObject;

                // Disable physics simulation for the picked object
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                // Store the original parent of the picked object
                originalParent = pickedObject.transform.parent;

                // Attach the picked object to the player's hand or attachment point
                pickedObject.transform.SetParent(transform);
            }
        }
    }

    private void ReleaseObject()
    {
        // Restore the original parent of the picked object
        pickedObject.transform.SetParent(originalParent);

        // Enable physics simulation for the picked object
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        // Reset the reference to the picked object
        pickedObject = null;
    }

    public void PickupCheck()
    {
        if (MainMenu.pickUp)
        {
            if (pickedObject == null)
            {
                PickupObject();
            }
            else
            {
                ReleaseObject();
            }
        }
    }
}
