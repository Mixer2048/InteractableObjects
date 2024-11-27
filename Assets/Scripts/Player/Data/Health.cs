using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<int, int> OnHealthChanged;

    [SerializeField, Range(1, 100)] private int maxHealth;
    [SerializeField, Range(1, 100)] private int currentHealth;

    public bool ChangeHealth(int amount)
    {
        if (currentHealth == maxHealth) return false;

        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth < 0)
            currentHealth = 0;

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        return true;
    }

    private void Awake() => OnHealthChanged?.Invoke(currentHealth, maxHealth);
}
