using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;    

    [System.Serializable]
    public class Pool
    {   
        public string tag;
        public GameObject prefab;     
        public int size;
        public Transform box;
    }    

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    public GameObject[] monster;
    public Transform monsterBox;
    public List<GameObject>[] monsterPools;

    private void Awake()
    {
        if(Instance == null) Instance = this;

        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, pool.box);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }        
            PoolDictionary.Add(pool.tag, objectPool);
        }

        monsterPools = new List<GameObject>[monster.Length];

        for (int i = 0; i < monsterPools.Length; i++)
        {
            monsterPools[i] = new List<GameObject>();
        }


    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in monsterPools[index])
        {
            if (!item.activeSelf)
            {
                select = item;                
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(monster[index], monsterBox);
            select.GetComponent<EnemyHealthSystem>().OnDeath += Spawner.Instance.OnEnemyDeath;
            monsterPools[index].Add(select);
        }

        return select;
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag)) return null;
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }
}
