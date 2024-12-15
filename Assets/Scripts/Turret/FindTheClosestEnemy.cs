using System.Collections.Generic;
using UnityEngine;

public class FindTheClosestEnemy : MonoBehaviour
{
    // List of enemies within range (private set, public get)
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

    private void Update()
    {
        // Periodically clean up dead enemies from the list
        Enemies.RemoveAll(enemy => enemy == null || enemy.IsDead);

        Debug.Log(Enemies.Count);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (!Enemies.Contains(enemy))
            {
                Enemies.Add(enemy);
            }
        }
    }

    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (Enemies.Contains(enemy))
            {
                Enemies.Remove(enemy);
            }
        }
    }

    public void SearchForClosestEnemies()
    {
        // Sort the enemies list by distance to this GameObject
        Enemies.Sort((enemy1, enemy2) =>
        {
            float dist1 = Vector3.Distance(transform.position, enemy1.transform.position);
            float dist2 = Vector3.Distance(transform.position, enemy2.transform.position);
            return dist1.CompareTo(dist2);
        });
    }

    public Enemy GetClosestEnemy()
    {
        if (Enemies.Count > 0)
        {
            return Enemies[0];
        }
        return null;
    }

    public Enemy GetSecondClosestEnemy()
    {
        if (Enemies.Count > 1)
        {
            return Enemies[1];
        }
        return null;
    }

    public Enemy GetThirdClosestEnemy()
    {
        if (Enemies.Count > 2)
        {
            return Enemies[2];
        }
        return null;
    }
}
