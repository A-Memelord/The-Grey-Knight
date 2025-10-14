using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteAlways]

public class SpawnHitbox : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public LayerMask attackLayer;

    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Attack2(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + (Vector3)playerController.direction, attackRadius, Vector2.zero, 0, attackLayer);

        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)playerController.direction, attackRadius);
    }
}
