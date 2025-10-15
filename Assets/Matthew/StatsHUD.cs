using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StatsHUD : MonoBehaviour
{
    public Stats stats;
    public TMPro.TMP_Text Hp;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hp.SetText(stats.currentHealth + " : " + stats.maxHealth);
    }
}
