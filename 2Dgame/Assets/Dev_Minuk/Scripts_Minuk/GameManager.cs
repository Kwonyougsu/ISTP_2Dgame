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
    public Transform items;
    public GameObject sPUI;

    public GameObject CloseAttack;
    public GameObject RangedAttack;
    public GameObject RotaionAttack;


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

    private void Update()
    {
        if (CloseWeaponCount == 2 && !CloseWeaponMax)
        {
            Destroy(CloseAttack);
            CloseWeaponMax = true;
        }
        if (RangedWeaponCount == 3 && !RangedWeaponMax)
        {
            Destroy(RangedAttack);
            RangedWeaponMax = true;
        }

        if (RotationWeaponCount == 3 && !RotationWeaponMax)
        {
            Destroy(RotaionAttack);
            RotationWeaponMax = true;
        }
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

    [Header("WeaponLevel")]
    public bool CloseWeapon;
    public bool RangedWeapon;
    public bool RotationWeapon;
    public int CloseWeaponCount;
    public int RangedWeaponCount;
    public int RotationWeaponCount;
    public bool CloseWeaponMax = false;
    public bool RangedWeaponMax = false;
    public bool RotationWeaponMax = false;

    public void StageDataReset() // 게임 시작과 종료시 호출
    {
        Lv = 0;
        maxExp = 100;
        curExp = 0;
        CloseWeapon = false;
        RangedWeapon = false;
        RotationWeapon = false;
        CloseWeaponCount = 0;
        RangedWeaponCount = 0;
        RotationWeaponCount = 0;

        if (stageGold > 0) // 혹시나 stageGlod에 -값이 들어갈까봐 (그럴일 없긴함)
        {
            playerGold += stageGold;
        }
        stageGold = 0;
        sp = 0;
        for (int i = 0; i < upgradeStatData.statLv.Length; i++)
        {
            upgradeStatData.statLv[i] = 0;
        }

        if(PlayerId == 0)
        {
            CloseWeapon = true;
            CloseWeaponCount = 1;
        }
        else if (PlayerId == 1)
        {
            RangedWeapon = true;
            RangedWeaponCount = 1;
        }
        else if (PlayerId == 2)
        {
            RotationWeapon = true;
            RotationWeaponCount = 1;
        }
    }
    public void LvUp()
    {
        Invoke("LateLvUp", 0.5f);
    }
    void LateLvUp()
    {
        if (curExp >= maxExp) curExp -= maxExp; // exp아이템을 한번에 먹었을 때 정상적으로 동작하지 않을 것 같아서
        Lv++;
        GameManager.Instance.maxExp += 20f;
        chooseItemUI.SetActive(true);
        while (true)
        {
            int ran = Random.Range(0, items.childCount);
            int ran1 = Random.Range(0, items.childCount);
            int ran2 = Random.Range(0, items.childCount);
            if(ran !=  ran1 && ran1 != ran2 && ran != ran2)
            {
                items.GetChild(ran).gameObject.SetActive(true);
                items.GetChild(ran1).gameObject.SetActive(true);
                items.GetChild(ran2).gameObject.SetActive(true);
                break;
            }
        }

        Time.timeScale = 0f;
    }
    public void SetCharacterId(int id)
    {
        PlayerId = id;
    }
}
