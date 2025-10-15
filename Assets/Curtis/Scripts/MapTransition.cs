using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] Collider2D mapBoundry;
    [SerializeField] Direction direction;
    [SerializeField] Transform roomTeleport;
    [SerializeField] Transform teleportTargetPosition;

    enum Direction { Up, Down, Left, Right, Teleport}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            UpdatePlayerPosition(collision.gameObject);

            roomTeleport.GetComponent<MapTransition>().teleportTargetPosition = gameObject.transform.GetChild(0);
        }
    }

    void UpdatePlayerPosition(GameObject player)
    {
        player.GetComponent<PlayerController>().StopAllCoroutines();
        player.GetComponent<PlayerController>().isMoving = false;

        if (direction == Direction.Teleport)
        {
            player.transform.position = teleportTargetPosition.position;

            return;
        }

        Vector3 additivePos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                additivePos.y += 2;
                break;
            case Direction.Down:
                additivePos.y += -2;
                break;
            case Direction.Left:
                additivePos.x += -2;
                break;
            case Direction.Right:
                additivePos.x += 2;
                break;
        }

        player.transform.position = additivePos;

    }
}
