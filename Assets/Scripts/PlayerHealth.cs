using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public float maxArmor = 50f;
    public float armor;

    public RectTransform HealthBar;
    public RectTransform ArmorBar;

    private float healthBarOriginalWidth;
    private float armorBarOriginalWidth;

    private void Start()
    {
        health = maxHealth;
        armor = maxArmor;

        healthBarOriginalWidth = HealthBar.sizeDelta.x;
        armorBarOriginalWidth = ArmorBar.sizeDelta.x;

        UpdateUI();
    }

    public void TakeDamage(float damage)
    {
        if(armor > 0)
        {
            armor -= damage;
            if(armor < 0)
            {
                health += armor;
                armor = 0;
            }
        }
        else
        {
            health -= damage;
        }

        health = Mathf.Clamp(health, 0, maxHealth);


        UpdateUI();

        if (health <= 0)
        {
            Debug.Log("Dead");
        }
    }

    private void UpdateUI()
    {
        HealthBar.sizeDelta = new Vector2(healthBarOriginalWidth * (health / maxHealth), HealthBar.sizeDelta.y);
        ArmorBar.sizeDelta = new Vector2(armorBarOriginalWidth * (armor / maxArmor), ArmorBar.sizeDelta.y);
    }
}
