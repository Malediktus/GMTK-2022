using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new data")]
public class DataContainer : ScriptableObject
{
    private void Awake()
    {
        //Player
        ExtraHealth = 0;
        ExtraBulletCount = 0;
        RangedDamageMultiplier = 1;
        MeleeDamageMultiplier = 1;
        MeleeReachMultiplier = 1;

        //Enemies
        EnemyHealthMultiplier = 1;
        EnemyShotgunBulletCount = 3;
        EnemyBulletForceMultiplier = 1;
    }

    //Player
    public float ExtraHealth;
    public int ExtraBulletCount;
    public float RangedDamageMultiplier;
    public float MeleeDamageMultiplier;
    public float MeleeReachMultiplier;

    //Enemies
    public float EnemyHealthMultiplier;
    public int EnemyShotgunBulletCount;
    public float EnemyBulletForceMultiplier;
}