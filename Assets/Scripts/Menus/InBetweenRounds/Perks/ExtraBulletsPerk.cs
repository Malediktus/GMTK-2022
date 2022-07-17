using System.Collections;
using UnityEngine;

public class ExtraBulletsPerk : MonoBehaviour, IPerk
{
    public DataContainer data;
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
            if (collision.gameObject.GetComponent<Die>().Equals(die))
            {
                die = null;
                DieValue = 0;
                hasDieOnTop = false;
            }
        }
    }

    public void ApplyPerk()
    {
        switch (DieValue)
        {
            case 0:
                data.ExtraBulletCount = 1;
                break;
            case 1:
                data.ExtraBulletCount = 2;
                break;
            case 2:
                data.ExtraBulletCount = 2;
                break;
            case 3:
                data.ExtraBulletCount = 3;
                break;
            case 4:
                data.ExtraBulletCount = 3;
                break;
            case 5:
                data.ExtraBulletCount = 4;
                break;
            case 6:
                data.ExtraBulletCount = 4;
                break;
        }
    }
}
