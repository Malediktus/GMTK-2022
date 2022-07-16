using System.Collections;
using UnityEngine;



public class Gun : MonoBehaviour
{

    public GameObject prefab;
    public float delay;
    public float bulletForce;
    public float damage;

    public Transform firePoint;
    private float _counter;

    private void Start()
    {
        damage *= GameManager.RangedDamageMultiplier;
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
        GameObject bullet = Instantiate(prefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<PlayerBullet>().damage = damage;
        Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
        bullet_rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
