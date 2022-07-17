using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health = 100f;
    private float lastHealth;
    public SpawnSystem spawnSystem;

    private void Start()
    {
        lastHealth = health;
        spawnSystem = GameObject.FindGameObjectWithTag("ArenaManager").GetComponent<SpawnSystem>();
    }

    private void FixedUpdate()
    {
        if (lastHealth != health)
        {
            StartCoroutine(HitAnim());
        }
        lastHealth = health;
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

    IEnumerator HitAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Animator>().SetBool("Hit", false);
    }
}
