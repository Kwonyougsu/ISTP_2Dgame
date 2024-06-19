using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyOnDeath : MonoBehaviour
{
    private EnemyHealthSystem healthSystem;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        healthSystem = GetComponent<EnemyHealthSystem>();
        rigidbody = GetComponent<Rigidbody2D>();        
        healthSystem.OnDeath += OnDeath;
    }

    void OnDeath()
    {       
        rigidbody.velocity = Vector3.zero;

        // �ǰݽ� �̹��� ȿ��, �ִϸ��̼�

        // 2�ʵڿ� �ı� - ���������� ȿ�� �� �ı��� ����
        Destroy(gameObject);
    }
}
