using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currentHealth;
    public float maxHealth;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateColor(ColorState state)
    {
        switch (state)
        {
            case ColorState.RED:
                healthBar.color = Color.red;
                break;
            case ColorState.GREEN:
                healthBar.color = Color.green;
                break;
            case ColorState.BLUE:
                healthBar.color = Color.blue;
                break;
        }
    }
}
