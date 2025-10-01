using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyAI2 : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    public float distanceBetween;

    // Add these fields for player reference and speed
    public UnityEngine.Transform player;
    public float speed;

    void Update()
    {
        if (!isMoving)
        {
            if (player != null)
            {
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

                if (input != Vector2.zero)
                {
                    var targetPos = transform.position + new Vector3(input.x, input.y, 0) * speed * Time.deltaTime;
                    StartCoroutine(Move(targetPos));
                }
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;

            transform.position = targetPos;

        }
        isMoving = false;
    }
}





















