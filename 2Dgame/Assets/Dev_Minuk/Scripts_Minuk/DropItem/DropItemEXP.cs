using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemEXP : MonoBehaviour
{
    [SerializeField] private AudioClip getExpClip;
    [SerializeField] private AudioClip lvUpClip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(getExpClip) SoundManager.PlayClip(getExpClip);
            GameManager.Instance.curExp += 100;
            if (GameManager.Instance.curExp >= GameManager.Instance.maxExp)
            {
                if (lvUpClip) SoundManager.PlayClip(lvUpClip);
                GameManager.Instance.LvUp();
            }
            Destroy(gameObject);
        }
    }
}
