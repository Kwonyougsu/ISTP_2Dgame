using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerAttack>() != null) //플레이어만 가지고 있는 컴포넌트
        {
            // 아이템 파괴
            Destroy(gameObject);
            // 드롭 아이템 선택 창 SetActive(true)
        }
    }
}
