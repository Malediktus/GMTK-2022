using System.Collections;
using UnityEngine;


public class EnemyShotgunCombat : MonoBehaviour
{
    public GameObject target;
    public DataContainer data;

    public GameObject BulletPrefab;
    public float damage;
    public float bulletForce;
    private float _counter = 0;
    public float shootDelay = 0.3f;
    public int bulletCount = 3;
    public int bulletSpreadAngle = 70;

    private void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player");
        bulletForce *= data.EnemyBulletForceMultiplier;
        bulletCount = data.EnemyShotgunBulletCount;
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
        Vector2 directiontoTargetNormalized = Quaternion.Euler(0, 0, -bulletSpreadAngle / 4) * directiontoTarget.normalized;
        float bulletOffset = bulletSpreadAngle / bulletCount;

        for(int i = 0; i < bulletCount; i++)
        {
            Vector3 dirForce =  Quaternion.Euler(0, 0, 45) * directiontoTargetNormalized;

            GameObject bullet = Instantiate(BulletPrefab, transform.position + new Vector3(directiontoTargetNormalized.x * 1f, directiontoTargetNormalized.y * 1f), transform.rotation);
            bullet.GetComponent<EnemyBullet>().damage = damage;
            Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
            bullet_rb.AddForce((Quaternion.Euler(0, 0, bulletOffset * i) * directiontoTargetNormalized) * bulletForce, ForceMode2D.Impulse);
        }
        
    }
}
