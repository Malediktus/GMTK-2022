using System.Collections;
using UnityEngine;

public class BasePerk : MonoBehaviour, IPerk
{
    Collider2D col2d;
    Die die;
    bool hasDieOnTop;
    private void Start()
    {
        Debug.Log("test");
        col2d = gameObject.GetComponent<Collider2D>();
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.CompareTag("Die"))
        {
            Debug.Log("Collision with Die");
            die = gameObject.GetComponent<Die>();
            hasDieOnTop = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Die")
        {
            die = null;
            hasDieOnTop = false;
        }
    }

    public void ApplyPerk()
    {
        throw new System.NotImplementedException();
    }
}
