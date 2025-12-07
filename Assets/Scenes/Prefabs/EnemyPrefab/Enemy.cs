using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int damage = 10;

    Transform player;
    Health playerHealth;
    NavMeshAgent agent;
    public GameObject healthDropPrefab;
    public GameObject bulletDropPrefab;
    public float dropChance = 0.5f;
    float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        // Move toward player
        agent.SetDestination(player.position);

        // Check if in attack range
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }
    }

    void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        TryDropItem();
        ScoreManager.AddPoints(100);
        Destroy(gameObject);
    }
    void TryDropItem()
    {
        // 70% chance to drop something
        if (Random.value <= 0.7f)
        {
            // 50/50 chance for health or bullets
            if (Random.value <= 0.5f)
            {
                if (healthDropPrefab != null)
                {
                    Instantiate(healthDropPrefab, transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (bulletDropPrefab != null)
                {
                    Instantiate(bulletDropPrefab, transform.position, Quaternion.identity);
                }
            }
        }
    }

}
