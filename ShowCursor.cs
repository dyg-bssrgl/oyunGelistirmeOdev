using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    void Start()
    {
        // Mouse imlecini etkinleştir
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
