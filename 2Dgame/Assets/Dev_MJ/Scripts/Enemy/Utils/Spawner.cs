using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    public Transform[] spawnPoint;
    public int curMonsterCount = 0;
    public int totalMonsterCount = 2;
    public int killCount = 0;

    private float timer;
    private float waveTimer;
    public int level = 1;
    private int monsterRange = 1;
    private bool isBoss = false;
    private bool isWave = false;
    private int bounusHP = 0;
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
        waveTimer += Time.deltaTime;

        if (waveTimer > 40f)
        {
            waveTimer = 0;
            WaveSpawn();
        }


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
        if (curMonsterCount >= totalMonsterCount || isWave || isBoss) return;

        GameObject enemy =  ObjectPool.Instance.Get(Random.Range(0, monsterRange));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<EnemyHealthSystem>().MaxHealth += bounusHP;
        enemy.GetComponent<EnemyHealthSystem>().CurrentHealth = enemy.GetComponent<EnemyHealthSystem>().MaxHealth;      
        curMonsterCount++;
    }

    private void WaveSpawn()
    {
        if (isBoss) return;

        isWave = true;
        GameObject[] wave = new GameObject[10];
        int num = Random.Range(1, spawnPoint.Length);
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy =  ObjectPool.Instance.Get(2);
            enemy.transform.position = spawnPoint[num].position;
            enemy.GetComponent<EnemyStatHandler>().CurrentStat.isChase = false;
            wave[i] = enemy;
            curMonsterCount++;
        }

        for(int i = 0; i < 10; i++)
        {            
            wave[i].GetComponent<EnemyStatHandler>().CurrentStat.isChase = true;            
        }
        isWave = false;
    }

    private void BossSpawn()
    {
        isBoss = true;
        GameObject enemy = ObjectPool.Instance.Get(3);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<EnemyHealthSystem>().MaxHealth += bounusHP;
        enemy.GetComponent<EnemyHealthSystem>().CurrentHealth = enemy.GetComponent<EnemyHealthSystem>().MaxHealth;
        curMonsterCount++;
    }

    private void ProcessLevelConditions()
    {
        if (level % 2 == 0)
        {
            totalMonsterCount += 2;
            if (totalMonsterCount >= 30) totalMonsterCount = 30;
        }

        if (level % 3 == 0)
        {            
            monsterRange++;
            if (monsterRange >= ObjectPool.Instance.monsterPools.Length) monsterRange--;
        }

        if (level % 5 == 0)
        {
            totalMonsterCount += 5;         
            if (totalMonsterCount >= 30) totalMonsterCount = 30;
        }

        if (level % 10 == 0)
        {
            bounusHP += 6;
            if (bounusHP >= 30) bounusHP = 110;
        }

        if (level % 15 == 0)
        {
            BossSpawn();
        }        
    }

    public void OnEnemyDeath()
    {
        curMonsterCount--;
        killCount++;
        LevelSystem();
    }

    public void OnBossDeath()
    {
        isBoss = false;
    }

    private void LevelSystem()
    {
        if (killCount >= 2)
        {
            level++;
            killCount = 0;
            ProcessLevelConditions();
        }
    }
}
