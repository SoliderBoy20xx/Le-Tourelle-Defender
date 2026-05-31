using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] 
    private float maxHealth = 100f;
    private float currentHealth;
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Base took {damage} damage, current health: {currentHealth}");
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            //GameManager.Instance.GameOver();
        }
    }
}