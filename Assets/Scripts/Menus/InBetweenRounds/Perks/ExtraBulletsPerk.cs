using System.Collections;
using UnityEngine;

<<<<<<< HEAD
using System.Collections;
using UnityEngine;


public class ExtraBulletsPerk : MonoBehaviour, IPerk
=======
public class ExtraBulletPerk : MonoBehaviour, IPerk
>>>>>>> 95dae2ac25008e98a82617394f9e4a0c932a2312
{
    Collider2D col2d;
    TextMesh textMesh;
    int DieValue = 0;
    string text = "Extra Bullets";
    Die die;
    bool hasDieOnTop;
    public Transform DieLocation;

    private void Start()
    {
        col2d = gameObject.GetComponent<Collider2D>();
        textMesh = gameObject.GetComponent<TextMesh>();
        setText();
    }

    public void setText()
    {
        textMesh.text = text;
        textMesh.fontSize = 100;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Die") && !hasDieOnTop)
        {
            die = collision.gameObject.GetComponent<Die>();
            die.inCollision = true;
            die.snapPosition = DieLocation.transform.position;
            DieValue = die.getValue();
            hasDieOnTop = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            die.inCollision = false;
            die = null;
            hasDieOnTop = false;

        }
    }

    public void ApplyPerk()
    {
        GameManager.ExtraBulletCount += Mathf.CeilToInt(.3f * DieValue);
    }
}
