using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public DataContainer data;
    public GameObject prefab;
    public float delay;
    public float bulletForce;
    public float damage;

    public Transform firePoint;
    private float _counter;

    private void Start()
    {
        
        damage *= data.RangedDamageMultiplier;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && _counter > delay)
        {
            Shoot();
            _counter = 0;
        }
        _counter += Time.deltaTime;
    }

    void Shoot()
    {
        for (int i = 0; i < data.ExtraBulletCount; i++)
        {
            Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 lookDir;
            lookDir = _mousePos - transform.position;

            GameObject bullet = Instantiate(prefab, transform.position + ((Vector3)lookDir.normalized * 1.5f), firePoint.rotation);
            bullet.GetComponent<PlayerBullet>().damage = damage;
            Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 forceDir = lookDir.normalized * bulletForce;
            forceDir.x += i * 5;
            bullet_rb.AddForce(forceDir, ForceMode2D.Impulse);
        }
    }
}
