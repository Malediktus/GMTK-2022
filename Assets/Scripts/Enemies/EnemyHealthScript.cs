using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health = 100f;

    private void FixedUpdate()
    {
        HealthCheck();
    }

    void HealthCheck()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
