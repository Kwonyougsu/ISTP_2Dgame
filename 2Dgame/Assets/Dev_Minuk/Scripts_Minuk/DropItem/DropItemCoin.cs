using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.stageGold += 100 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 100);
            Destroy(gameObject);
        }
    }
}
