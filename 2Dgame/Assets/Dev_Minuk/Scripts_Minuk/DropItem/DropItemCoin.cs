using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCoin : MonoBehaviour
{
    public float coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.stageGold += coin + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * coin);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        if(coin == 0f)
        {
            coin = 100f;
        }
    }
}
