using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Animator playerAnimator;
    public float damage;
    public float lifeTime = 60f;
    float counter = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerSprite")
        {
            Debug.Log("Hit");
            playerAnimator = collision.gameObject.GetComponent<Animator>();
            collision.gameObject.GetComponent<Player>().health -= damage;
            StartCoroutine(HurtAnim());
        }
        else
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        counter += Time.fixedDeltaTime;
        if (counter >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator HurtAnim()
    {
        playerAnimator.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.1f);
        playerAnimator.SetBool("Hurt", false);
        Destroy(gameObject);
    }
}
