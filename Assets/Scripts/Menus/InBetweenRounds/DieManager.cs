using System.Collections;
using UnityEngine;

public class DieManager : MonoBehaviour
{
    public Transform DiceStartingPos;
    public GameObject DiePrefab;
    public int baseDiceNum = 5;
    public int extraDice = 0;
    void Start()
    {
        //float offset = DiePrefab.transform.localScale.x * 1.5f;
        float offset = 5f / 2f;
        for(int i = 0; i < baseDiceNum + extraDice; i++)
        {
            Vector3 Position = DiceStartingPos.position + new Vector3(offset * i, 0, 0);
            GameObject dieObj = GameObject.Instantiate(DiePrefab, Position, DiceStartingPos.rotation, DiceStartingPos);
            Die die = dieObj.GetComponent<Die>();
            die.UpdateValue(Random.Range(1, 6));
        }
    }


}
