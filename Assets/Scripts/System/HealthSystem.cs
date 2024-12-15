
using UnityEngine;

public class HealthSystem
{

    private int maxHealth;
    private float health;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int GetMaxHealth() => maxHealth;
    public float GetHealth() => health;

    public void Damage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
    }

    public void Heal(float heal)
    {
        health = Mathf.Clamp(health + heal, 0, maxHealth);
    }

    public void IncreaseMaxHealthByPercentage(int percentage)
    {

        percentage = percentage / 100;

        maxHealth = (int)(maxHealth * percentage);

    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

}
