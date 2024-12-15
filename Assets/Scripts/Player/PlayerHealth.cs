using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    private void Start()
    {
        healthSystem = new HealthSystem(100);
        UpdateUI();
    }

    public override void UpdateUI()
    {
        base.UpdateUI();
    }

    public override void GetDamage(float damage)
    {
        healthSystem.Damage(damage);
        UpdateUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(10);
        }
    }

}
