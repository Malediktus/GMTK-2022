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
        
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir;
        lookDir = _mousePos - transform.position;



        GameObject bullet = Instantiate(prefab, transform.position + ((Vector3) lookDir.normalized * 1.5f), firePoint.rotation);
        bullet.GetComponent<PlayerBullet>().damage = damage;
        Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
        bullet_rb.AddForce(lookDir.normalized * bulletForce, ForceMode2D.Impulse);
    }
}
