using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null) //�÷��̾ ������ �ִ� ������Ʈ
        {
            GameManager.Instance.stageGold += 100;
            Destroy(gameObject);
        }
    }
}
