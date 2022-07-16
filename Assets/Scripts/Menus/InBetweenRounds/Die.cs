using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Die : MonoBehaviour
{
    [SerializeField]
    private int Value = 0;
    public bool isSelected = false;
    public List<Sprite> sprites;
    private bool wasJustSelected;
    public bool inCollision;
    public Vector2 snapPosition;



    public void UpdateValue(int value)
    {
        Value = value;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Value - 1];
    }

    public int getValue()
    {
        return Value;
    }
    void Update()
    {
        if (isSelected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 9);
        }
    }
}
