using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    void Start()
    {
        // Mouse imlecini etkinle�tir
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
