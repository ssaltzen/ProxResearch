using UnityEngine;
public class MouseLock : MonoBehaviour
{

    private bool isLocked = true;
    void Start()
    {
        LockMouse();
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void UpdateMousePosition()
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
