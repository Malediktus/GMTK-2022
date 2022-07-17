using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DataContainer data;
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

    private Rigidbody2D rb;
    private EnemyHealthScript _healthScript;

    public float stuck_moveTimer = 3f;
    public float stuck_counter = 0f;
    public Vector2 stuck_last_pos;
    private Animator animator;
    private SpriteRenderer srenderer;


    private void Start()
    {
        srenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        stuck_last_pos = new Vector2(0, 0);
        health *= data.EnemyHealthMultiplier;
        speed *= data.EnemySpeedMultiplier;
        target = GameObject.FindGameObjectWithTag("Player");
        _healthScript = gameObject.GetComponent<EnemyHealthScript>();
        _healthScript.health = health;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!target)
            Destroy(gameObject);

        Vector3 selfPosition = transform.position;
        Vector2 selfPositionVect2 = new Vector2(selfPosition.x, selfPosition.y);
        Vector2 directiontoTarget = target.transform.position - selfPosition;


        if (Vector2.Distance(target.transform.position, transform.position) > targetDistance && Mathf.Abs(Vector2.Distance(target.transform.position, transform.position)) > targetDistance + marginToTaget)
        {
            rb.velocity = (directiontoTarget.normalized * speed + interferance).normalized * speed;
        }
        else if(Vector2.Distance(target.transform.position, transform.position) < runAwayDistance)
        {
            rb.velocity = (-directiontoTarget.normalized * speed + interferance).normalized * speed;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

        animator.SetFloat("Speed", rb.velocity.x > 0 || rb.velocity.y > 0 ? 1f : 0f);
        
        if(directiontoTarget.x > 0)
        {
            srenderer.flipX = false;
        }else if(directiontoTarget.x < 0)
        {
            srenderer.flipX = true;
        }
        


    }

    private void FixedUpdate()
    {
        if (interferanceTicksCount >= ticksBetweenInterferance)
        {
            interferance = Random.insideUnitCircle.normalized * randomInterferance;
            interferanceTicksCount = 0;
        }

        interferanceTicksCount += Time.fixedDeltaTime;

        if(stuck_counter >= stuck_moveTimer)
        {
            if(stuck_last_pos == (Vector2)transform.position && Vector2.Distance(transform.position, target.transform.position) > targetDistance * 1.5f)
            {
                transform.position += new Vector3(0, 2, 0);
                stuck_counter = 0;
            }
            stuck_last_pos = transform.position;
        }

        stuck_counter += Time.fixedDeltaTime;
    }


}
