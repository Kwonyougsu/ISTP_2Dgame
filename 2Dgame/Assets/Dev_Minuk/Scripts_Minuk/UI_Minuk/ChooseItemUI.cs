using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseItemUI : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;

    GameObject chooseItemUI;
    private void Awake()
    {
        chooseItemUI = this.gameObject;
        GameManager.Instance.chooseItemUI = chooseItemUI;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        coinTxt.text = $"°ñµå È¹µæ\nGold + {200 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 200)}";
    }


    public void ChooseSP()
    {
        Time.timeScale = 1f;
        GameManager.Instance.sp++;
        gameObject.SetActive(false);
    }

    public void ChooseHp()
    {
        Time.timeScale = 1f;
        // ÇÃ·¹ÀÌ¾î Ã¼·Â 50% È¸º¹
        gameObject.SetActive(false);
    }

    public void ChooseCoin()
    {
        Time.timeScale = 1f;
        GameManager.Instance.stageGold += 200 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 200);
        gameObject.SetActive(false);
    }
}
