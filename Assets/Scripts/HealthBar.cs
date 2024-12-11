using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
   private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void incrementMaxHealth (int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void UpdateHealthValue(int healthActual)
    {
        slider.value = healthActual;
    }

    public void initializeHealthBar(int healthValue)
    {
        incrementMaxHealth(healthValue);
        UpdateHealthValue(healthValue);
    }
}
