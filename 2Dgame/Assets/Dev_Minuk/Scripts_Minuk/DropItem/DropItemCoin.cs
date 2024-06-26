using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCoin : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(clip) SoundManager.PlayClip(clip);
            GameManager.Instance.stageGold += 100 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 100);
            Destroy(gameObject);
        }
    }
}
