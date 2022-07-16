using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceAnimation : MonoBehaviour
{
    public SpriteRenderer rend;
    public Sprite[] diceSides;
    private int finalSide;

    public int RollTheDice()
    {
        StartCoroutine(RollDice());
        return finalSide;
    }

    IEnumerator RollDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;

        for (int i = 0; i < 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);

            rend.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(0.05f + (i * 0.01f));
        }

        finalSide = randomDiceSide + 1;
    }
}