using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle }
public class GameControlloer : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    GameState state;
    void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
            {
                state = GameState.FreeRoam;
            }
        };
    }

    void Update()
    {
        if (state == GameState.FreeRoam)
        {
            pc.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {

        }
    }
}
