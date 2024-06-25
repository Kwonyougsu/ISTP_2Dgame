using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Purchasing;
using UnityEngine;

public class ChooseItemUI : MonoBehaviour
{
    public TextMeshProUGUI coinTxt;

    GameObject chooseItemUI;
    private PlayerHealthSystem playerHealthSystem;
    public Transform items;

    private void Awake()
    {
        chooseItemUI = this.gameObject;
        GameManager.Instance.chooseItemUI = chooseItemUI;
        for(int i =0; i < items.childCount; i++)
        {
            items.GetChild(i).gameObject.SetActive(false);
        }
        GameManager.Instance.items = items;

    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        coinTxt.text = $"골드 획득\nGold + {200 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 200)}";
    }


    public void ChooseSP()
    {
        Time.timeScale = 1f;
        GameManager.Instance.sp++;
        Activefalse();
        gameObject.SetActive(false);
    }

    public void ChooseHp()
    {
        Time.timeScale = 1f;
        float healvalue = playerHealthSystem.MaxHealth / 2;
        playerHealthSystem.Heal(healvalue);
        Activefalse();
        gameObject.SetActive(false);
    }

    public void ChooseCoin()
    {
        Time.timeScale = 1f;
        GameManager.Instance.stageGold += 200 + (GameManager.Instance.upgradeStatData.statLv[3] * 0.1f * 200);

        Activefalse();
        gameObject.SetActive(false);
    }
    #region ���� ���� 
    public void ChooseCloseWeapon()
    {
        Time.timeScale = 1f;
        if (GameManager.Instance.CloseWeapon)
        {
            GameManager.Instance.CloseWeaponCount++;
        }
        else
        {
            GameManager.Instance.CloseWeapon = true;
            GameManager.Instance.CloseWeaponCount = 1;
        }

        Activefalse();
        gameObject.SetActive(false);
    }
    public void ChooseRangedWeapon()
    {
        Time.timeScale = 1f;
        if (GameManager.Instance.RangedWeapon)
        {
            GameManager.Instance.RangedWeaponCount++;
        }
        else
        {
            GameManager.Instance.RangedWeapon = true;
            GameManager.Instance.RangedWeaponCount = 1;
        }

        Activefalse();
        gameObject.SetActive(false);
    }
    public void ChooseRotationWeapon()
    {
        Time.timeScale = 1f;
        if (GameManager.Instance.RotationWeapon)
        {
            GameManager.Instance.RotationWeaponCount++;
        }
        else
        {
            GameManager.Instance.RotationWeapon = true;
            GameManager.Instance.RotationWeaponCount = 1;
        }

        Activefalse();
        gameObject.SetActive(false);
    }
    #endregion

    public void Activefalse()
    {
        for(int i = 0; i < items.childCount; i++)
        {
            items.GetChild(i).gameObject.SetActive(false);
        }
    }
}
