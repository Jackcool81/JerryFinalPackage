using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public UnityEvent OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int value)
    {
        print("Changing Health");
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        print(currentHealth);
        if(currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
