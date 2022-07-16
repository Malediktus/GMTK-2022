using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    public Text waveDisplay;
    public GameObject player;
    public Player playerClass;
    public float Radius = 20f;
    public List<GameObject> EnemyList;
    public int enemysAlive = 0;
    public int wave = 1;
    public int baseEnemysPerWave = 4;
    public float increasePerWave = 1 / 4;

    void Start()
    {
        newWave();
        playerClass = player.GetComponent<Player>();
    }

    public void enemyDied()
    {
        enemysAlive--;
        if(enemysAlive <= 0)
        {
            // Open Between Rounds Menu
            playerClass.health = playerClass.maxHealth;
            newWave();
        }
    }

    void newWave()
    {
        int enemys = baseEnemysPerWave + Mathf.FloorToInt(increasePerWave * wave);
        enemysAlive = enemys;

        for(int i = 0; i < enemys; i++)
        {
            GameObject enemyprefab = EnemyList[Random.Range(0, EnemyList.Count)];

            GameObject enemyobject = GameObject.Instantiate(enemyprefab, (Vector3) randomPointInCircle(), transform.rotation);
            enemyobject.GetComponent<Enemy>().target = player;
            enemyobject.GetComponent<EnemyHealthScript>().spawnSystem = this;
        }

        wave++;
        waveDisplay.text = ("Wave: " + wave);
    }

    Vector2 randomPointInCircle()
    {
        return Random.insideUnitCircle * Radius;

    }
}
