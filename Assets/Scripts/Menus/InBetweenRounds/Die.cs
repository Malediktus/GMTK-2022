using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Die : MonoBehaviour
{
    [SerializeField]
    private int Value = 0;
    public bool isSelected = false;
    public List<Sprite> sprites;



    public void UpdateValue(int value)
    {
        Value = value;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Value - 1];
    }
    void Update()
    {
        if (isSelected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 9);
        }
    }
}
