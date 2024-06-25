using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseItemUI : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;

    GameObject chooseItemUI;
    private PlayerHealthSystem playerHealthSystem;
    private void Awake()
    {
        chooseItemUI = this.gameObject;
        GameManager.Instance.chooseItemUI = chooseItemUI;
        playerHealthSystem = FindObjectOfType<PlayerHealthSystem>();
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
        float healvalue = playerHealthSystem.MaxHealth / 2;
        playerHealthSystem.Heal(healvalue);
        gameObject.SetActive(false);
    }

    public void ChooseCoin()
    {
        Time.timeScale = 1f;
        GameManager.Instance.stageGold += 200 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 200);
        gameObject.SetActive(false);
    }
}
