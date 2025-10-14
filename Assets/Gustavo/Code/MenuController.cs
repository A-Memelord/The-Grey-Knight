using JetBrains.Annotations;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseManager.instance.IsPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    
        
    }
    public void Pause()
    {
        PauseManager.instance.PauseGame();
    }
    
    public void Unpause()
    {
        PauseManager.instance.UnpauseGame();

    }
    

}
