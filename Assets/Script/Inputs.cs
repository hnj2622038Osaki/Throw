using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;
    public bool fire;
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
    public void OnFire(InputValue value)
    {
        fire = value.isPressed;
    }
}
