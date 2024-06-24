using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public TopDownMovement playerDirection;
    public Transform player;

    public GameObject chooseItemUI;
    public GameObject sPUI;

    public Transform Player
    {
        get { return player; }
        private set { player = value; }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    public int PlayerId;


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(_instance != this)
            {
                Destroy(gameObject);
            }
        }
        Lv = 0;
        maxExp = 100;
        curExp = 0;
        playerGold = 0;
        stageGold = 0;
    }

    [Header("Need Connection")]
    public ItemData itemData;
    public UpgradeStatData upgradeStatData;

    [Header("Player")]
    public int Lv;
    public float maxExp;
    public float curExp;
    public float playerGold;
    public float stageGold;
    public int sp;

    public void StageDataReset() // 게임 시작과 종료시 호출
    {
        Lv = 0;
        maxExp = 100;
        curExp = 0;
        if(stageGold > 0) // 혹시나 stageGlod에 -값이 들어갈까봐 (그럴일 없긴함)
        {
            playerGold += stageGold;
        }
        stageGold = 0;
        sp = 0;
        for (int i = 0; i < upgradeStatData.statLv.Length; i++)
        {
            upgradeStatData.statLv[i] = 0;
        }
    }
    public void LvUp()
    {
        if(curExp >= maxExp) curExp -= maxExp; // exp아이템을 한번에 먹었을 때 정상적으로 동작하지 않을 것 같아서
        Lv++;
        GameManager.Instance.maxExp += 20f;
        chooseItemUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void SetCharacterId(int id)
    {
        PlayerId = id;
    }
}
