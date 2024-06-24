using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private int currentWaveIndex = 0;
    [SerializeField] private int currentSpawnCount = 0;
    [SerializeField] private int waveSpawnCount = 0;
    [SerializeField] private int waveSpawnPosCount = 0;
    [SerializeField] private int deathCount = 0;

    public float spawnInterval = .5f;
    public List<GameObject> enemyPrefebs = new List<GameObject>();
    [SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPositions = new List<Transform>();
    //private ObjectPool objectPool = ObjectPool.Instance;
    //임시 플레이어 위치
    private Transform playerPos;

    private void Awake()
    {
        for (int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }
    }

    private void Start()
    {
        //UpgradeStatInit();       
        StartCoroutine(StartNextWave());
        playerPos = GameManager.Instance.player;

    }

    public void UpdatePosition()
    {
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Vector3 distans = playerPos.position - spawnPositions[i].position;
            spawnPositions[i].position = playerPos.position + distans;
        }        
    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            if (currentSpawnCount == 0)
            {
                yield return new WaitForSeconds(2f);

                ProcessWaveConditions();
                //Debug.Log($"GameManager.cs - StartNextWave() - ProcessWaveConditions()실행 이후 currentWaveIndex: {currentWaveIndex}, waveSpawnPosCount: {waveSpawnPosCount}, waveSpawnCount: {waveSpawnCount}");

                yield return StartCoroutine(SpawnEnemiesInWave());
               
                currentWaveIndex++;
            }
            yield return null;
        }
    }

    void ProcessWaveConditions()
    {
        if (currentWaveIndex % 20 == 0)
        {
            RandomUpgrade();
        }

        if (currentWaveIndex % 10 == 0)
        {
            IncreaseSpawnPositions();
        }

        if (currentWaveIndex % 5 == 0)
        {
            CreateReward();
        }

        if (currentWaveIndex % 3 == 0)
        {
            IncreaseWaveSpawnCount();
        }
    }

    private void IncreaseWaveSpawnCount()
    {
        waveSpawnCount += 1;
        //Debug.Log($"GameManager.cs - IncreaseWaveSpawnCount() - 종료 currentWaveIndex: {currentWaveIndex}, waveSpawnPosCount: {waveSpawnPosCount}, waveSpawnCount: {waveSpawnCount}");
    }
    private void CreateReward()
    {
        //Debug.Log("CreateReward 호출");
    }

    private void RandomUpgrade()
    {
        //Debug.Log("RandomUpgrade 호출");

    }

    void IncreaseSpawnPositions()
    {
        //Debug.Log($"GameManager.cs - IncreaseSpawnPositions() - 진입 currentWaveIndex: {currentWaveIndex}, waveSpawnPosCount: {waveSpawnPosCount}, waveSpawnCount: {waveSpawnCount},  spawnPositions.Count: {spawnPositions.Count}, is: {waveSpawnPosCount + 1 > spawnPositions.Count}");

        waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
        if (currentWaveIndex == 0) waveSpawnCount = 0;
        else waveSpawnCount = 1;
        //Debug.Log($"GameManager.cs - IncreaseSpawnPositions() - 종료 currentWaveIndex: {currentWaveIndex}, waveSpawnPosCount: {waveSpawnPosCount}, waveSpawnCount: {waveSpawnCount}");
    }
    IEnumerator SpawnEnemiesInWave()
    {
        for (int i = 0; i < waveSpawnPosCount; i++)
        {            
            int posIdx = Random.Range(0, spawnPositions.Count);
            for (int j = 0; j < waveSpawnCount; j++)
            {
                SpawnEnemyAtPosition(posIdx);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    void SpawnEnemyAtPosition(int posIdx)
    {
        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity);
        enemy.GetComponent<EnemyHealthSystem>().OnDeath += OnEnemyDeath;
        currentSpawnCount++;
    }

    private void OnEnemyDeath()
    {
        currentSpawnCount--;
        deathCount++;
    }
}
