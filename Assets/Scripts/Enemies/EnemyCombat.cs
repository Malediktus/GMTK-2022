using System.Collections;
using UnityEngine;


public class EnemyCombat : MonoBehaviour
{
    public GameObject target;


    public GameObject BulletPrefab;
    public float damage;
    public float bulletForce;
    private float _counter = 0;
    public float shootDelay = 0.3f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        bulletForce *= GameManager.EnemyBulletForceMultiplier;
    }

    private void FixedUpdate()
    {
        if (_counter >= shootDelay)
        {
            Shoot();
            _counter = 0;
        }

        _counter += Time.fixedDeltaTime;


    }

    private void Shoot()
    {
        Vector2 directiontoTarget = target.transform.position - transform.position;
        Vector2 directiontoTargetNormalized = directiontoTarget.normalized;
        Quaternion rot = Quaternion.Euler(directiontoTargetNormalized);

        GameObject bullet = Instantiate(BulletPrefab, transform.position + new Vector3(directiontoTargetNormalized.x * 1f, directiontoTargetNormalized.y * 1f), transform.rotation);
        bullet.GetComponent<EnemyBullet>().damage = damage;
        Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
        bullet_rb.AddForce(directiontoTargetNormalized * bulletForce, ForceMode2D.Impulse);
    }
}
