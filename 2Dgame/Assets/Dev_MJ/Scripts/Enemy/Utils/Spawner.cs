using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;


    public Transform[] spawnPoint;
    public int curMonsterCount = 0;
    public int totalMonsterCount = 0;

    private float timer;
    private int level;

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

        GameObject enemy =  ObjectPool.Instance.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        curMonsterCount++;
    }

    public void OnEnemyDeath()
    {
        curMonsterCount--;        
    }
}
