using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevellSceneSwitch : MonoBehaviour
{
    public string LevelName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}
