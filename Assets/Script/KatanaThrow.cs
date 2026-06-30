using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class KatanaThrow : MonoBehaviour
{
    [SerializeField] GameObject katanaPrefab;
    [SerializeField] AudioClip BGM;
    [SerializeField] Transform throwPoint;      // “Š‚°‚éˆÊ’u
    [SerializeField] float throwForce = 10f;    // “Š‚°‚é‹­‚³
    [SerializeField] float idleTime = 10.0f;

    private float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("Throw", false);
        time += Time.deltaTime;
        if (time > idleTime)
        {
            time = 0f;
            ThrowKatana();
            GetComponent<Animator>().SetBool("Throw", true);
        }
    }

    void ThrowKatana()
    {
        GameObject katana = Instantiate(katanaPrefab, throwPoint.position, Quaternion.identity);

        Rigidbody rb = katana.GetComponent<Rigidbody>();

        // ‘O•ûŒü‚É”­ŽË
        rb.linearVelocity = transform.forward * throwForce;
    }

}
