using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DropItemBox : MonoBehaviour
{
    public AudioClip clip;

    public Transform items;
    private void Awake()
    {
        items = GameManager.Instance.items;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerAttack>() != null) //�÷��̾ ������ �ִ� ������Ʈ
        {
            if (clip) SoundManager.PlayClip(clip);

            // ��� ������ ���� â SetActive(true)
            GameManager.Instance.chooseItemUI.SetActive(true);
            while (true)
            {
                int ran = Random.Range(0, items.childCount);
                int ran1 = Random.Range(0, items.childCount);
                int ran2 = Random.Range(0, items.childCount);
                if (ran != ran1 && ran1 != ran2 && ran != ran2)
                {
                    items.GetChild(ran).gameObject.SetActive(true);
                    items.GetChild(ran1).gameObject.SetActive(true);
                    items.GetChild(ran2).gameObject.SetActive(true);
                    break;
                }
            }
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }
}
