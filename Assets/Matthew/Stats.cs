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
}
