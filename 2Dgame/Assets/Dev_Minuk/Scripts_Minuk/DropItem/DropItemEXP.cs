using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemEXP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.curExp += 100;
            if (GameManager.Instance.curExp >= GameManager.Instance.maxExp)
            {
                GameManager.Instance.LvUp();
            }
            Destroy(gameObject);
        }
    }
}
