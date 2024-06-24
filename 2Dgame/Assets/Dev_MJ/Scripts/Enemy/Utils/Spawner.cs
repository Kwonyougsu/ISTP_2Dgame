using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;


    public Transform[] spawnPoint;
    public int curMonsterCount = 0;
    public int totalMonsterCount = 2;
    public int killCount = 0;

    private float timer;
    public int level = 1;
    private int monsterRange = 1;
    private bool isBoos = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        


        if (timer > 1f)
        {
            timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        if (curMonsterCount >= totalMonsterCount) return;

        GameObject enemy =  ObjectPool.Instance.Get(Random.Range(0, monsterRange));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        curMonsterCount++;
    }

    private void ProcessLevelConditions()
    {
        if (level % 2 == 0)
        {
            totalMonsterCount++;
            if (totalMonsterCount >= 20) totalMonsterCount = 20;
        }

        if (level % 3 == 0)
        {
            monsterRange++;
            if (monsterRange > ObjectPool.Instance.monsterPools.Length) monsterRange--;
        }

        if (level % 5 == 0)
        {
            totalMonsterCount += 5;
            if (totalMonsterCount >= 20) totalMonsterCount = 20;
        }


    }

    public void OnEnemyDeath()
    {
        curMonsterCount--;
        killCount++;
        LevelSystem();
    }

    private void LevelSystem()
    {
        if (killCount >= 3)
        {
            level++;
            killCount = 0;
            ProcessLevelConditions();
        }
    }
}
