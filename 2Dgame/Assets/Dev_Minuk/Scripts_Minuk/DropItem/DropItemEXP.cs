using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemEXP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerStats>() != null) //�÷��̾ ������ �ִ� ������Ʈ
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
