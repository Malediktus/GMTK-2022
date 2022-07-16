using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedDebuff : MonoBehaviour, IPerk
{
    public DataContainer data;
    Collider2D col2d;
    TextMesh textMesh;
    int DieValue = 0;
    string text = "Enemy Speed nerf";
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
            DieValue = 0;
            hasDieOnTop = false;

        }
    }

    public void ApplyPerk()
    {
        Debug.Log("Test please");
        switch (DieValue)
        {
            case 0:
                data.EnemySpeedMultiplier = 1f;
                break;
            case 1:
                data.EnemySpeedMultiplier = 0.9f;
                break;
            case 2:
                data.EnemySpeedMultiplier = 0.8f;
                break;
            case 3:
                data.EnemySpeedMultiplier = 0.7f;
                break;
            case 4:
                data.EnemySpeedMultiplier = 0.6f;
                break;
            case 5:
                data.EnemySpeedMultiplier = 0.5f;
                break;
            case 6:
                data.EnemySpeedMultiplier = 0.4f;
                break;
        }
        Debug.Log(data.EnemySpeedMultiplier);
    }
}
