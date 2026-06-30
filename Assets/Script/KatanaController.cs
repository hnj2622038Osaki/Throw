using UnityEngine;

public class KatanaController : MonoBehaviour
{
    public float rotateSpeed = 720f;   // ‰ñ“]ƒXƒs[ƒh
    public float lifeTime = 5f;        // ©“®Á–Å

    void Start()
    {
        // ˆê’èŠÔ‚ÅÁ‚¦‚é
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        // ‰ñ“]
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // ‚Ô‚Â‚©‚Á‚½‚ç~‚Ü‚é
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
    }
}