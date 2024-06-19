using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerAttack>() != null) //플레이어만 가지고 있는 컴포넌트
        {
            // 스테이지에서 획득한 골드증가
            // 아이템 파괴
            Destroy(gameObject);
        }
    }
}
