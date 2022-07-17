using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Die : MonoBehaviour
{
    [SerializeField]
    private int Value = 0;
    public bool isSelected = false;
    public List<Sprite> sprites;
    public bool inCollision;
    public Vector2 initialPosition;
    public Vector2 snapPosition;
    public bool isInPerk = false;

    public void UpdateValue()
    {
        Value = gameObject.GetComponent<DiceAnimation>().RollTheDice();
    }

    public int getValue()
    {
        return Value;
    }

    void Update()
    {
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isSelected)
        {
            transform.position = mouseWorldPosition + new Vector3(0, 0, 9);
            isInPerk = false;
        }
        if(!isSelected && !isInPerk)
        {
            if (inCollision){
                // Snap die to perk position
                transform.position = snapPosition;
                isInPerk = true;
            }
            else {
                // Return to initial poision
                transform.position = initialPosition;
                isInPerk = false;
            }
        }
        // if(!isSelected && !inCollision && !isInPerk)
        // {
            
        // }
    }
}
