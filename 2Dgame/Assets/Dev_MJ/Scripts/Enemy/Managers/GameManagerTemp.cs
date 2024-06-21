using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTemp : MonoBehaviour
{
    public static GameManagerTemp Instance;

    public Transform player;
    public Transform Player 
    {   
        get { return player; }
        private set { player = value; }
    }

    private void Awake()
    {
        // 인스턴스가 이미 생성 되었다면 게임 매니저 오브젝트 파괴 
        if (Instance != null) Destroy(gameObject);

        Instance = this;
    }

  
}
