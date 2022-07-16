using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DataContainer data;

    public float health = 75f;
    public float maxHealth = 75f;

    public float hittingRange = 1f;
    public float hittingDamage = 3f;

    public float speed = 10f;
    public float slowDown = 5f;
    public float aceleration = 20f;

    public Camera cam;

    private Rigidbody2D _rb;
    private Vector2 _mousePos;

    public Animator animator;
    public bool playerFacingRight;


    private void Start()
    {
        
        _rb = gameObject.GetComponent<Rigidbody2D>();
        health += data.ExtraHealth;
        maxHealth += data.ExtraHealth;
        Debug.Log(data.ExtraHealth);

        hittingDamage *= data.MeleeDamageMultiplier;
        hittingRange *= data.MeleeReachMultiplier;
    }

    private void Update()
    {
        Move();

        animator.SetFloat("speed", Mathf.Abs(_rb.velocity.magnitude));

        // Hitting
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, hittingRange);
        foreach(var hitCollider in colliders)
        {
            if (Input.GetMouseButtonDown(1) && hitCollider.gameObject.TryGetComponent<EnemyHealthScript>(out EnemyHealthScript healthScript))
            {
                hitCollider.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                healthScript.health -= hittingDamage;
            }
        }
    }

    private void FixedUpdate()
    {
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }

        gameObject.GetComponent<HealthBar>().SetMaxValue((int)maxHealth);
        gameObject.GetComponent<HealthBar>().SetHealth((int)health);
    }
    /*
     
    private void Aim()
    {
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir;
        lookDir = _mousePos - _rb.position;
        _rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }


     */


    private void Move()
    {
        // Geting Input
        var inputHorizontal = Input.GetAxisRaw("Horizontal");
        var inputVertical = Input.GetAxisRaw("Vertical");

        Vector2 inputVector = new Vector2(inputHorizontal, inputVertical);
        _rb.velocity += aceleration * Time.deltaTime * inputVector;

        // Decent way to do movement
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -speed, speed), Mathf.Clamp(_rb.velocity.y, -speed, speed));

        // Shity Way to Make Player stop when no Input is Given For x Axis
        if (inputVector.x == 0 && _rb.velocity.x > 0) { _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x - slowDown * Time.deltaTime, 0, 10), _rb.velocity.y); }
        else if (inputVector.x == 0 && _rb.velocity.x < 0) { _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x + slowDown * Time.deltaTime, -10, 0), _rb.velocity.y); }

        // Shity Way to Make Player stop when no Input is Given For y Axis
        if (inputVector.y == 0 && _rb.velocity.y > 0) { _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y - slowDown * Time.deltaTime, 0, 10)); }
        else if (inputVector.y == 0 && _rb.velocity.y < 0) { _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y + slowDown * Time.deltaTime, -10, 0)); }

        // Flip sprite based on input
        if (inputHorizontal > 0 && !playerFacingRight){flipFace();}
        if (inputHorizontal < 0 && playerFacingRight){flipFace();}
    }

    private void flipFace()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        playerFacingRight = !playerFacingRight;
    }
}

