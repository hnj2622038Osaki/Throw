using UnityEngine;

public class KatanaContrller : MonoBehaviour
{
    [SerializeField] AudioClip hitTargetSe;
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "target")
        {
            AudioSource.PlayClipAtPoint(hitTargetSe, transform.position);
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
