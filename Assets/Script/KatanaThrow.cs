using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class KatanaThrow : MonoBehaviour
{
    [SerializeField] GameObject katanaPrefab;
    [SerializeField] AudioClip BGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject katana = Instantiate(katanaPrefab);
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
            katana.GetComponent<KatanaContrller>().Shoot(ray.direction * 2000);

        }
    }
}
