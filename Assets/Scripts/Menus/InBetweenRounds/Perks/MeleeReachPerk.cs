using System.Collections;
using UnityEngine;


public class MeleeReachPerk : MonoBehaviour, IPerk
{
    Collider2D col2d;
    TextMesh textMesh;
    int DieValue = 0;
    string text = "Extra Health";
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
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
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
        if (collision.gameObject.tag == "Die")
        {
            die.inCollision = false;
            die = null;
            hasDieOnTop = false;

        }
    }

    public void ApplyPerk()
    {
        GameManager.MeleeReachMultiplier = .15f * DieValue;
    }
}
