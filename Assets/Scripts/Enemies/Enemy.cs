using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // States
    public bool playerInSightRange;
    public bool IsDead { get; private set; } = false; // New property to check if the enemy is dead

    private void Awake()
    {
        if (!player)
            player = GameObject.Find("Car Player").transform;

        if (!agent)
            agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = player != null;

        if (!IsDead && playerInSightRange) ChasePlayer();
    }

    private void ChasePlayer()
    {
        if (agent.enabled) // Ensure the agent is active
            agent.SetDestination(player.position);
    }

    public void Die()
    {
        IsDead = true;
        agent.enabled = false; // Disable the NavMeshAgent
        // Optional: Play death effects or animations here
        Destroy(gameObject, 0.1f); // Destroy the GameObject after a short delay
    }
}
