﻿using System.Collections;
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

    void CyclePerks()
    {
        for(int i = 0; i < perkPositions.Count; i++)
        {
            if(i <= 3)
            {
                Instantiate(PositivePerkPrefabs[Random.Range(0, PositivePerkPrefabs.Count)], perkPositions[i]);
            }
            else
            {
                Instantiate(NegativePerkPrefabs[Random.Range(0, NegativePerkPrefabs.Count)], perkPositions[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
