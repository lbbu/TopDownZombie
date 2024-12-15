using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public Vector3 enemyPos { get; set; } // Target enemy position
    public float speed = 10f; // Speed of the projectile
    public float rotateSpeed = 5f; // Speed of rotation towards the target

    private Vector3 firstPos;
    private Vector3 afterPos;


    private void Start()
    {
        firstPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        RotateToEnemyPosition();
        GoToEnemyPosition();

        afterPos = transform.position;

        if(Vector3.Distance(firstPos, afterPos) >= 14)
        {
            Destroy(gameObject);
        }

    }

    // Rotate towards the enemy's position
    private void RotateToEnemyPosition()
    {
        if (enemyPos != null)
        {
            Vector3 direction = enemyPos - transform.position; // Direction to the target
            Quaternion lookRotation = Quaternion.LookRotation(direction); // Desired rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime); // Smooth rotation
        }
    }

    // Move towards the enemy's position
    private void GoToEnemyPosition()
    {
        if (enemyPos != null)
        {
            Vector3 direction = (enemyPos - transform.position).normalized; // Direction vector
            transform.position += direction * speed * Time.deltaTime; // Move in the direction of the target
        }
    }

    // Detect collision with the enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZombieHealth>())
        {
            // Apply damage to the enemy
            other.gameObject.GetComponent<ZombieHealth>().GetDamage(10);

            // Destroy the projectile after hitting the enemy
            Destroy(gameObject);

            Debug.Log("Trigger");
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.GetComponent<ZombieHealth>())
        {
            // Apply damage to the enemy
            other.gameObject.GetComponent<ZombieHealth>().GetDamage(10);

            // Destroy the projectile after hitting the enemy
            Destroy(gameObject);

            Debug.Log("Collision");

        }

    }
}
