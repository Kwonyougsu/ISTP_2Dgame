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

        // 피격시 이미지 효과, 애니메이션

        // 2초뒤에 파괴 - 투명해지는 효과 후 파괴를 위해
        Destroy(gameObject);
    }
}
