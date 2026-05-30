using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 200f;
    public float health;

    public float maxArmor = 100f;
    public float armor;

    public RectTransform HealthBar;
    public RectTransform ArmorBar;

    private float healthBarOriginalWidth;
    private float armorBarOriginalWidth;

    public GameObject gameOverPanel;

    private void Start()
    {
        health = maxHealth;
        if(GameManager.Instance != null)
        {
            armor = GameManager.Instance.armor;
        }
        
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

            if(GameManager.Instance != null)
            {
                GameManager.Instance.armor = armor;
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
            Die();
        }
    }

    private void UpdateUI()
    {
        HealthBar.sizeDelta = new Vector2(healthBarOriginalWidth * (health / maxHealth), HealthBar.sizeDelta.y);
        ArmorBar.sizeDelta = new Vector2(armorBarOriginalWidth * (armor / maxArmor), ArmorBar.sizeDelta.y);
    }

    void Die()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        PlayerMoney money = GetComponent<PlayerMoney>();

        money.money = 0;

        gameOverPanel.SetActive(true);

        PlayerMovement movement = GetComponent<PlayerMovement>();
        movement.enabled = false;

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Lobby");
    }
}
