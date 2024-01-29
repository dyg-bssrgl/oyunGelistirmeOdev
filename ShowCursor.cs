using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    void Start()
    {
        // Mouse imlecini etkinleþtir
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
