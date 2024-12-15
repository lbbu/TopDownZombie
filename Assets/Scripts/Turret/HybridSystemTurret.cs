using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HybridSystemTurret : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public Transform firePoint; // Point from where the projectile is fired
    public float fireRate = 1f; // How often the turret fires (in seconds)
    public float range = 15f; // Range of the turret
    public float randomFireAngle = 45f; // Angle range for random firing

    [SerializeField] private FindTheClosestEnemy enemyFinder;
    private float fireTimer;

    void Start()
    {
        //enemyFinder = GetComponent<FindTheClosestEnemy>(); // Reference to the enemy-finder script
        fireTimer = 0f;
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        // Fire a projectile when the timer exceeds the fire rate
        if (fireTimer >= fireRate)
        {
            FireProjectile();
            fireTimer = 0f;
        }
    }

    private void FireProjectile()
    {
        enemyFinder.SearchForClosestEnemies(); // Update the sorted list of enemies
        Enemy closestEnemy = enemyFinder.GetClosestEnemy();

        if (closestEnemy != null && Vector3.Distance(transform.position, closestEnemy.transform.position) <= range)
        {
            // Primary mode: Shoot at the closest enemy
            ShootAtEnemy(closestEnemy.transform.position);
        }
        else
        {
            // Secondary mode: Shoot randomly
            ShootRandomly();
        }
    }

    private void ShootAtEnemy(Vector3 targetPosition)
    {
        // Rotate turret to face the enemy
        RotateToTarget(targetPosition);

        // Instantiate and shoot the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        TurretProjectile turretProjectile = projectile.GetComponent<TurretProjectile>();
        turretProjectile.enemyPos = targetPosition;
    }

    private void ShootRandomly()
    {
        // Generate a random direction within the specified angle
        float randomAngle = Random.Range(-randomFireAngle, randomFireAngle);
        Quaternion randomRotation = Quaternion.Euler(0, randomAngle, 0);
        Vector3 randomDirection = randomRotation * transform.forward;

        // Rotate turret to face the random direction
        RotateToTarget(transform.position + randomDirection);

        // Instantiate and shoot the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        TurretProjectile turretProjectile = projectile.GetComponent<TurretProjectile>();
        turretProjectile.enemyPos = transform.position + randomDirection * range; // Set a point in the random direction
    }

    private void RotateToTarget(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; // Keep rotation in the horizontal plane
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
