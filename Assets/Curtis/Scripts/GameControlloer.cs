using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle }
public class GameControlloer : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    GameState state;
    void Start()
    {
        
    }

    void Update()
    {
        if (state == GameState.FreeRoam)
        {
            pc.HandleUpdate();

        }
        else if (state == GameState.Dialog)
        {

        }
        else if (state == GameState.Battle)
        {

        }
    }
}
