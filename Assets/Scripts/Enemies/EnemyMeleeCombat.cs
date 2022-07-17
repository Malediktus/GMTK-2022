using System.Collections;
using UnityEngine;


public class EnemyMeleeCombat : MonoBehaviour
{

    public GameObject target;
    public DataContainer data;

    public float damage;
    public float reach = 1.5f;
    private float _counter = 0;
    public float shootDelay = 0.3f;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
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

        float distanceToTarget = Vector2.Distance(target.transform.position, transform.position);
        if(distanceToTarget <= reach)
        {
            target.GetComponent<Player>().health -= damage;

            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Player/Combat/PlayerHit", gameObject);
        }
    }
}

