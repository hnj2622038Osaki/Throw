
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    private Vector3 direction;
    private float changeTime = 0f;

    void Update()
    {
        // ˆê’èŽžŠÔ‚²‚Æ‚Éƒ‰ƒ“ƒ_ƒ€‚È•ûŒü‚ðŒˆ‚ß‚é
        changeTime -= Time.deltaTime;

        if (changeTime <= 0f)
        {
            direction = new Vector3(
                Random.Range(-1f, 1f),
                0f,
                Random.Range(-1f, 1f)
            ).normalized;

            changeTime = Random.Range(1f, 3f); // ŽŸ‚É•ûŒü•Ï‚¦‚é‚Ü‚Å‚ÌŽžŠÔ

            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }

        // ˆÚ“®
        transform.position += direction * speed * Time.deltaTime;
    }
}

