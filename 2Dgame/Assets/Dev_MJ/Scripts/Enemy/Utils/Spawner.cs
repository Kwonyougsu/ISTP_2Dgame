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

    private Transform playerPos;
    private Vector3[] vector3s = new Vector3[10];


    private void Awake()
    {
        if (Instance == null) Instance = this;
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        playerPos = GameManager.Instance.player;

        for (int i = 1; i < spawnPoint.Length; i++)
        {           
            Vector3 distans = spawnPoint[i].position - playerPos.position;
            spawnPoint[i].position = playerPos.position + distans;
            vector3s[i-1] = distans;  
        }

    }

    private void Update()
    {     
        UpdatePosition();
        timer += Time.deltaTime;
        
        if (timer > 1f)
        {
            timer = 0;
            Spawn();
        }
    }

    public void UpdatePosition()
    {
        for (int i = 0; i < vector3s.Length; i++)
        {
            spawnPoint[i+1].position = playerPos.position + vector3s[i];
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
