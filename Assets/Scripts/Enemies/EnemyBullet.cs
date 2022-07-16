using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;
    public float lifeTime = 60f;



    float counter = 0f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= damage;
        }
        Destroy(gameObject);
        

        
    }

    private void FixedUpdate()
    {
        counter += Time.fixedDeltaTime;
        if (counter >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
