using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerAttack>() != null) //�÷��̾ ������ �ִ� ������Ʈ
        {
            // ������ �ı�
            Destroy(gameObject);
            // ��� ������ ���� â SetActive(true)
        }
    }
}
