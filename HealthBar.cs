using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // UI'deki Image componenti
    public float maxHealth = 100f;
    private float currentHealth;
    public string gameOverSceneName = "TheEnd";

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBarImage.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    // Örnek: Can yenileme metodu
    public void Heal(float healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }
}
