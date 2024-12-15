using UnityEngine;

public class ZombieHealth : Health
{
    private Enemy enemy;

    private void Start()
    {
        healthSystem = new HealthSystem(100);
        UpdateUI();
        enemy = GetComponent<Enemy>();
    }

    public override void GetDamage(float damage)
    {
        healthSystem.Damage(damage);

        if (healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        if (enemy != null)
        {
            enemy.Die(); // Mark the enemy as dead
        }
        base.Die();
    }
}
