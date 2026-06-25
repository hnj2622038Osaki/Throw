using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    Inputs inputs;
    CharacterController controller;
    Vector3 velocity;
    void Start()
    {
        // コンポーネント取得
        inputs = GetComponent<Inputs>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        // 移動量
        velocity.x = inputs.move.x * moveSpeed;
        velocity.z = inputs.move.y * moveSpeed;
        // 落下
        if (controller.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        // 移動
        controller.Move(velocity * Time.deltaTime);
    }
}
