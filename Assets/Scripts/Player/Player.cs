using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;

    public float speed = 10f;
    public float slowDown = 5f;
    public float aceleration = 20f;

    public Camera cam;

    private Rigidbody2D _rb;
    private Vector2 _mousePos;


    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Aim();
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
    }

    private void Aim()
    {
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir;
        lookDir = _mousePos - _rb.position;
        _rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    private void Move()
    {
        // Geting Input
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.velocity += aceleration * Time.deltaTime * inputVector;

        // Decent way to do movement
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -speed, speed), Mathf.Clamp(_rb.velocity.y, -speed, speed));

        // Shity Way to Make Player stop when no Input is Given For x Axis
        if (inputVector.x == 0 && _rb.velocity.x > 0) { _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x - slowDown * Time.deltaTime, 0, 10), _rb.velocity.y); }
        else if (inputVector.x == 0 && _rb.velocity.x < 0) { _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x + slowDown * Time.deltaTime, -10, 0), _rb.velocity.y); }

        // Shity Way to Make Player stop when no Input is Given For y Axis
        if (inputVector.y == 0 && _rb.velocity.y > 0) { _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y - slowDown * Time.deltaTime, 0, 10)); }
        else if (inputVector.y == 0 && _rb.velocity.y < 0) { _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y + slowDown * Time.deltaTime, -10, 0)); }
    }
}

