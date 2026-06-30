using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 1;
    public LayerMask enemyLayer;

    private PlayerInputAction inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Attack.performed += OnAttack;
    }
    void OnDisable()
    {
        inputActions.Player.Attack.performed -= OnAttack;
        inputActions.Disable();
    }
    void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("UŒ‚");

        // UŒ‚ˆ—
        Attack();
    }
    void Attack()
    {
        // ƒvƒŒƒCƒ„[‘O•û‚ÉUŒ‚”ÍˆÍ‚ğì‚é
        Collider[] hits = Physics.OverlapSphere(
            transform.position + transform.forward,
            attackRange,
            enemyLayer
        );

        foreach (Collider hit in hits)
        {
            Debug.Log("“G‚É–½’†");
            Destroy(hit.gameObject);
        }
    }
    // ”ÍˆÍ‚ğŒ©‚¦‚é‰»
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, attackRange);
    }
}