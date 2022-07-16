using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health = 100f;
    public SpawnSystem spawnSystem;

    private void Start()
    {
        spawnSystem = GameObject.FindGameObjectWithTag("ArenaManager").GetComponent<SpawnSystem>();
    }

    private void FixedUpdate()
    {
        HealthCheck();
    }

    void HealthCheck()
    {
        if (health <= 0f)
        {
            spawnSystem.enemyDied();
            Destroy(gameObject);
        }
    }
}
