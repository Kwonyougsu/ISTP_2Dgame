using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemEXP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerStats>() != null) //플레이어만 가지고 있는 컴포넌트
        {
            GameManager.Instance.curExp += 10;
            if (GameManager.Instance.curExp >= GameManager.Instance.maxExp)
            {
                GameManager.Instance.LvUp();
            }
            Destroy(gameObject);
        }
    }
}
