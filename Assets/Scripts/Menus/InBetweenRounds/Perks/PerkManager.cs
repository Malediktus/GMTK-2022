using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PerkManager : MonoBehaviour
{
    /*
     * if you are reading this, you are probabily wondering why every single perk has a prefab
     * instead of a better OOP aproach, but you see, im tired and it works kinda (i think)
     */
    public List<GameObject> PositivePerkPrefabs;
    public List<GameObject> NegativePerkPrefabs;
    public List<Transform> perkPositions;

    // Use this for initialization
    void Start()
    {
        GameObject perkParent = GameObject.Find("PerkPositions");
        for (int i = 0; i < perkParent.transform.childCount; i++)
        {
            perkPositions.Add(perkParent.transform.GetChild(i));
        }

        CyclePerks();
        
    }

    void MakePrefabs()
    {

    }

    void CyclePerks()
    {
        for(int i = 0; i < perkPositions.Count; i++)
        {
            GameObject obj;
            if(i <= 3)
            {
                obj = Instantiate(PositivePerkPrefabs[Random.Range(0, PositivePerkPrefabs.Count)], perkPositions[i]);
                Debug.Log(PositivePerkPrefabs[Random.Range(0, PositivePerkPrefabs.Count)], perkPositions[i]);
            }
            else
            {
                obj = Instantiate(NegativePerkPrefabs[Random.Range(0, NegativePerkPrefabs.Count)], perkPositions[i]);
            }     

        }
    }

    public void ApplyPerks()
    {
        for(int i = 0; i < PositivePerkPrefabs.Count; i++)
        {
            IPerk iperk = PositivePerkPrefabs[i].GetComponent(typeof(IPerk)) as IPerk;
            iperk.ApplyPerk();
        }
        for (int i = 0; i < NegativePerkPrefabs.Count; i++)
        {
            IPerk iperk = NegativePerkPrefabs[i].GetComponent(typeof(IPerk)) as IPerk;
            iperk.ApplyPerk();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
