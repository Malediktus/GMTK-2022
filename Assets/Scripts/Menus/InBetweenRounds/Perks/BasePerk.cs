using System.Collections;
using UnityEngine;

public class BasePerk : MonoBehaviour, IPerk
{
    Collider2D col2d;
    TextMesh textMesh;
    Die die;
    bool hasDieOnTop;
    public Transform DieLocation;
    private void Start()
    {
        col2d = gameObject.GetComponent<Collider2D>();
        textMesh = gameObject.GetComponent<TextMesh>();
        setText();
    }

    void setText()
    {
        textMesh.text = "BasePerk";
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Die"))
        {
            die = collision.gameObject.GetComponent<Die>();
            die.inCollision = true;
            die.snapPosition = DieLocation.transform.position;
            hasDieOnTop = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Die")
        {
            die.inCollision = false;
            die = null;
            hasDieOnTop = false;

        }
    }

    public void ApplyPerk()
    {
        throw new System.NotImplementedException();
    }
}
