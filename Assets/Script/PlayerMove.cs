using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] string flontKey;
    [SerializeField] string backKey;
    [SerializeField] string rightKey;
    [SerializeField] string leftKey;
    [SerializeField] string jumpKey;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float jumpForce = 600.0f;

    private Rigidbody2D rigid;
    private bool Grounded;
    private float timer = 0f;

    float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        GetComponent<Animator>().SetBool("Run", false);
        // 前に移動
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.Translate(0, 0, moveSpeed);
            GetComponent<Animator>().SetBool("Run", true);
        }
        // 後ろに移動
        if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(0, 0, -moveSpeed);
            GetComponent<Animator>().SetBool("Run", true);
        }
        // ジャンプ
        if (Keyboard.current.spaceKey.wasPressedThisFrame && rigid.linearVelocityY == 0)
        {
            //rigid.AddForce(transform.up * jumpForce);
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    // 地面との接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("ゲームオーバー");
            SceneManager.LoadScene("OverScene");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = false;
        }
    }
}
