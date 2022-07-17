using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new data")]
public class DataContainer : ScriptableObject
{
    private void OnEnable()
    {
        //Player
        ExtraHealth = 0;
        ExtraBulletCount = 1;
        RangedDamageMultiplier = 1;
        MeleeDamageMultiplier = 1;
        MeleeReachMultiplier = 1;

        //Enemies
        EnemySpeedMultiplier = 1;
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
    public float EnemySpeedMultiplier;
    public float EnemyHealthMultiplier;
    public int EnemyShotgunBulletCount;
    public float EnemyBulletForceMultiplier;
}