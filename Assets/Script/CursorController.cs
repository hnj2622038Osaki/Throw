using UnityEngine;
public class CursorController : MonoBehaviour
{
    void Start()
    {
        // マウスカーソル非表示
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
