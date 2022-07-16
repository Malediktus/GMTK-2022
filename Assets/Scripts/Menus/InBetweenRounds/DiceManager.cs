using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public Transform DiceStartingPos;
    public GameObject DiePrefab;
    public static int baseDiceNum = 5;
    public static int extraDice = 0;
    public List<GameObject> DiceList;
    void Start()
    {
        //float offset = DiePrefab.transform.localScale.x * 1.5f;
        float offset = 5f / 2f;
        for(int i = 0; i < baseDiceNum + extraDice; i++)
        {
            Vector3 Position = DiceStartingPos.position + new Vector3(offset * i, 0, 0);
            GameObject dieObj = GameObject.Instantiate(DiePrefab, Position, DiceStartingPos.rotation, DiceStartingPos);
            Die die = dieObj.GetComponent<Die>();
            die.UpdateValue();
            DiceList.Add(dieObj);
        }
    }

    bool AreAllDiceUsed()
    {
        for(int i = 0; i < DiceList.Count; i++)
        {
            if (!gameObject.GetComponent<Die>().isInPerk)
                return false;
        }
        return true;
    }


}
