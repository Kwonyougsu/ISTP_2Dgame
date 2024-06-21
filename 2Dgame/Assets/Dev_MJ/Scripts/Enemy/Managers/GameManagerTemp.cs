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
        // �ν��Ͻ��� �̹� ���� �Ǿ��ٸ� ���� �Ŵ��� ������Ʈ �ı� 
        if (Instance != null) Destroy(gameObject);

        Instance = this;
    }

  
}
