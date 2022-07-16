using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerkManager : MonoBehaviour
{
    /*
     * if you are reading this, you are probabily wondering why every single perk has a prefab
     * instead of a better OOP aproach, but you see, im tired and it works kinda (i think)
     */

    public DataContainer data;
    public List<TMP_Text> texts;
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
                int index = Random.Range(0, PositivePerkPrefabs.Count);
                obj = Instantiate(PositivePerkPrefabs[index], perkPositions[i]);
                PositivePerkPrefabs.RemoveAt(index);
            }
            else
            {
                int index = Random.Range(0, NegativePerkPrefabs.Count);
                obj = Instantiate(NegativePerkPrefabs[index], perkPositions[i]);
                NegativePerkPrefabs.RemoveAt(index);
            }

        }
    }

    public void ApplyPerks()
    {
        foreach (Transform positions in transform)
        {
            foreach (Transform perkObjects in positions)
            {
                foreach (Transform child in perkObjects)
                {
                    IPerk iperk = child.GetComponent(typeof(IPerk)) as IPerk;
                    if (iperk != null)
                        iperk.ApplyPerk();
                }
            }
        }
    }

    void Update()
    {
        texts[0].text = "Extra Health: " + data.ExtraHealth;
        texts[1].text = "Extra Bullets: " + data.ExtraBulletCount;
        texts[2].text = "Extra Range Damage: " + data.RangedDamageMultiplier;
        texts[3].text = "Extra Melee Damage: " + data.MeleeDamageMultiplier;
        texts[4].text = "Extra Melee Range: " + data.MeleeReachMultiplier;
        texts[5].text = "Enemy Speed Multi: " + data.EnemySpeedMultiplier;
        texts[6].text = "Enemy Health Multi: " + data.EnemyHealthMultiplier;
        texts[7].text = "Enemy Shutgun Bullets: " + data.EnemyShotgunBulletCount;
        texts[8].text = "Enemy Bullet Force: " + data.EnemyBulletForceMultiplier;
    }
}
