using UnityEngine;

public class Stats : MonoBehaviour
{
    [Tooltip("this entity's max health.")] [Range(1, 100)] public float maxHealth;
    [HideInInspector] public float currentHealth;

    [Header("Attack")]

    [Tooltip("this entity's damage output.")] [Range(1, 100)] public float Damage;
    [Tooltip("this entity's defense. defens is subtractive from damage.")] [Range(1, 50)] public float defense;

    [Header("Death")]

    [Tooltip("weather or not this entity is dead.")] public bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent(out Stats stats))
            {
                stats.currentHealth -= 1;
            }
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (currentHealth <= 0 && gameObject.CompareTag("Player"))
        {

        }
        

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
            
    }
}
