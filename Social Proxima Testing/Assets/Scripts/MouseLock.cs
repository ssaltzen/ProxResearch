using UnityEngine;

public class MouseLock : MonoBehaviour
{
    void Start()
    {
        LockMouse();
    }

    void Update()
    {
        UpdateMousePosition();
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UpdateMousePosition()
    {
        float x = Screen.width / 2f;
        float y = Screen.height / 2f;
        Cursor.SetCursor(null, new Vector2(x, y), CursorMode.Auto);
    }
}
