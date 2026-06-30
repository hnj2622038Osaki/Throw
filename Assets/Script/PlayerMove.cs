using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
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
        // カメラの平面ベクトルを作成
        Vector3 cameraForward = Vector3.Scale(
        Camera.main.transform.forward,
        new Vector3(1, 0, 1)
        ).normalized;

        // カメラの向きを考慮した移動量
        Vector3 planeVel = cameraForward * inputs.move.y
        + Camera.main.transform.right * inputs.move.x;

        // 移動中、進行方向にゆっくり向く
        if (inputs.move != Vector2.zero)
        {
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(planeVel.normalized),
            0.2f);
        }

        // 移動速度
        planeVel *= moveSpeed;
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
        controller.Move(velocity * Time.deltaTime); GetComponent<Animator>().SetBool("Walk", true);

    }
}
