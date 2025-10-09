using System.IO;
using UnityEngine;
using Unity.Cinemachine;


public class SaveController : MonoBehaviour
{
    private string saveLocation;
    void Start()
    {
        // define save location
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");

        LoadGame(); 
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindWithTag("Player").transform.position,
            
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));

    }

    public void LoadGame()
    {
        if(File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindWithTag("Player").transform.position = saveData.playerPosition;

            
        }
        else
        {
            SaveGame();
        }


    }


}
