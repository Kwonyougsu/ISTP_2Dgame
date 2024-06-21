using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public TopDownMovement playerDirection;
    public Transform player;

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

    [Header("Player")]
    public int Lv;
    public float maxExp;
    public float curExp;
    public int playerGold;
    public int stageGold;

    public void StageDataReset() // ���� ���۰� ����� ȣ��
    {
        Lv = 0;
        maxExp = 100;
        curExp = 0;
        if(stageGold > 0) // Ȥ�ó� stageGlod�� -���� ����� (�׷��� ������)
        {
            playerGold += stageGold;
        }
        stageGold = 0;
    }
    public void LvUp()
    {
        if(curExp >= maxExp) curExp -= maxExp; // exp�������� �ѹ��� �Ծ��� �� ���������� �������� ���� �� ���Ƽ�
        Lv++;
    }
    public void SetCharacterId(int id)
    {
        PlayerId = id;
    }
}
