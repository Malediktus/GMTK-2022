using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float randomInterferance = 2f;
    public float ticksBetweenInterferance = 200;
    private float interferanceTicksCount;
    public Vector2 interferance = new Vector2(0,0);
    public float targetDistance = 5f;
    public float runAwaySpped = 2.5f;
    public float runAwayDistance = 3f;
    public float health;
    public float marginToTaget = 1f;



    public GameObject target;

    public GameObject slimeBallPrefab;
    public float damage;
    public float bulletForce;

    private Rigidbody2D rb;
    private EnemyHealthScript _healthScript;
    private float _counter = 0;
    public float shootDelay = 0.3f;

    private void Start()
    {
        _healthScript = gameObject.GetComponent<EnemyHealthScript>();
        _healthScript.health = health;
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        Vector3 selfPosition = transform.position;
        Vector2 selfPositionVect2 = new Vector2(selfPosition.x, selfPosition.y);
        Vector2 directiontoTarget = target.transform.position - selfPosition;


        if (Vector2.Distance(target.transform.position, transform.position) > targetDistance && Mathf.Abs(Vector2.Distance(target.transform.position, transform.position)) > targetDistance + marginToTaget)
        {
            rb.velocity = directiontoTarget.normalized * speed + interferance;
        }
        else if(Vector2.Distance(target.transform.position, transform.position) < runAwayDistance)
        {
            rb.velocity = -directiontoTarget.normalized * runAwaySpped + interferance;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }


    }

    private void FixedUpdate()
    {
        if (_counter >= shootDelay)
        {
            Shoot();
            _counter = 0;
        }

        _counter += Time.fixedDeltaTime;

        if(interferanceTicksCount >= ticksBetweenInterferance)
        {
            interferance = Random.insideUnitCircle.normalized * randomInterferance;
            interferanceTicksCount = 0;
        }

        interferanceTicksCount += Time.fixedDeltaTime;
    }

    private void Shoot()
    {
        Vector2 directiontoTarget = target.transform.position - transform.position;
        Vector2 directiontoTargetNormalized = directiontoTarget.normalized;

        GameObject bullet = Instantiate(slimeBallPrefab, transform.position + new Vector3(directiontoTargetNormalized.x * 1f, directiontoTargetNormalized.y * 1f), transform.rotation);
        bullet.GetComponent<EnemyBullet>().damage = damage;
        Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
        bullet_rb.AddForce(directiontoTargetNormalized * bulletForce, ForceMode2D.Impulse);
    }
}
