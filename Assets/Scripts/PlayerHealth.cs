using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBar;
    public TextMeshProUGUI healthText;
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    public void SetHealth(int health)
    {
        healthBar.value = health;
    }

    
    public void disPlayCurrentHealth(int health)
    {
        healthText.text = health.ToString();
    }

    
}
