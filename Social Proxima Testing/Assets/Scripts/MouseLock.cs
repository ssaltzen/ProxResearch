using UnityEngine;
public class MouseLock : MonoBehaviour
{
    [SerializeField] 
    private GameObject virtualCamera;

    private bool isLocked = true;

    private void Start()
    {
        LockMouse();
    }

    private void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        virtualCamera.GetComponent<Cinemachine.CinemachineInputProvider>().enabled = true;
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        virtualCamera.GetComponent<Cinemachine.CinemachineInputProvider>().enabled = false;
    }

    private void UpdateMousePosition()
    {
        float x = Screen.width / 2f;
        float y = Screen.height / 2f;
        Cursor.SetCursor(null, new Vector2(x, y), CursorMode.Auto);
    }

    public void UpdateMouseState()
    {
        isLocked = !isLocked;
        if (isLocked)
        {
            LockMouse();
        }
        else
        {
            UnlockMouse();
        }
        
        if (isLocked)
        {
            UpdateMousePosition();
        }
    }
}
