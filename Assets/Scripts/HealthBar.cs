using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health playerHealth;
    public Slider healthSlider;

    void Start()
    {
        playerHealth.OnHealthChanged += UpdateHealthBar;
    }

    void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    void OnDestroy()
    {
        playerHealth.OnHealthChanged -= UpdateHealthBar;
    }
}
