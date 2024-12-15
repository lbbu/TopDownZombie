using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected Slider healthSlider;
    [SerializeField] protected TextMeshProUGUI healthText;

    protected HealthSystem healthSystem;

    protected virtual void Start()
    {
        healthSystem = new HealthSystem(100);
        UpdateUI();
    }

    public virtual void UpdateUI()
    {
        healthSlider.value = healthSystem.GetHealth() / healthSystem.GetMaxHealth();
        healthText.text = healthSystem.GetHealth().ToString();
    }

    public virtual void GetDamage(float damage)
    {
        
        UpdateUI();
    }

    public virtual void Heal(float amount)
    {
        
        UpdateUI();
    }

    public virtual void IncreaseMaxHealth(float amount)
    {
        
        UpdateUI();
    }

    public virtual void Die()
    {
        // Implement common death behavior here if needed
    }
}
