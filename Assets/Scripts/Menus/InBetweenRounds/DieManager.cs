using System.Collections;
using UnityEngine;

public class DieManager : MonoBehaviour
{
    public Transform DiceStartingPos;
    public GameObject Die;
    public int baseDiceNum = 5;
    public int extraDice = 0;
    void Start()
    {
        float offset = Die.transform.localScale.x * 1.5f;
        for(int i = 0; i < baseDiceNum + extraDice; i++)
        {
            Vector3 Position = DiceStartingPos.position + new Vector3(offset * i, 0, 0);
            GameObject.Instantiate(Die, Position, DiceStartingPos.rotation, DiceStartingPos);
        }
    }


}
