using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyAI2 : MonoBehaviour
{
    private bool isMoving;
    private Vector2 input;
    public float distanceBetween;
    public UnityEngine.Transform player;
    public float speed;

    // Wandering variables
    private Vector2 wanderDirection;
    private float wanderTimer;
    private float wanderInterval = 2f; // seconds

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) <= distanceBetween)
        {
            // Chase the player
            Vector2 direction = player.position - transform.position;

            // Only move in X or Y direction, not diagonally
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                input = new Vector2(Mathf.Sign(direction.x), 0);
            }
            else if (Mathf.Abs(direction.y) > 0)
            {
                input = new Vector2(0, Mathf.Sign(direction.y));
            }
            else
            {
                input = Vector2.zero;
            }

            if (input != Vector2.zero && !isMoving)
            {
                var targetPos = transform.position + new Vector3(input.x, input.y, 0) * speed * Time.deltaTime;
                StartCoroutine(Move(targetPos));
            }
        }
        else
        {
            // Random wandering
            wanderTimer -= Time.deltaTime;
            if (wanderTimer <= 0f)
            {
                // Pick a new random direction (X or Y only)
                int axis = Random.Range(0, 2); // 0 = X, 1 = Y
                float dir = Random.value < 0.5f ? -1f : 1f;
                wanderDirection = axis == 0 ? new Vector2(dir, 0) : new Vector2(0, dir);
                wanderTimer = wanderInterval;
            }

            if (wanderDirection != Vector2.zero && !isMoving)
            {
                var targetPos = transform.position + new Vector3(wanderDirection.x, wanderDirection.y, 0) * speed * Time.deltaTime;
                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            yield return null;
            transform.position = targetPos;
        }
        isMoving = false;
    }
}























