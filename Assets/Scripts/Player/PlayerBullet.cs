using System.Collections;
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
    public float damage;
    public float lifeTime = 60f;



    float counter = 0f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealthScript>(out EnemyHealthScript healthScript))
        {
            healthScript.health -= damage;

            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Enemies/Combat/EnemyHit", gameObject);
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
