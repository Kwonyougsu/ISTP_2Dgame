using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SPUI : MonoBehaviour
{
    public UpgradeStatData upgradeStatData;

    public Image[] icon;
    public TextMeshProUGUI[] statLvTxt;
    public TextMeshProUGUI[] statNameTxt;
    public TextMeshProUGUI[] statDescriptionTxt;
    public TextMeshProUGUI spTxt;

    private void Awake()
    {
        GameManager.Instance.sPUI = this.gameObject;
        upgradeStatData = GameManager.Instance.upgradeStatData;
        for (int i = 0; i < upgradeStatData.statName.Length; i++)
        {
            icon[i].sprite = upgradeStatData.statIcon[i];
            statNameTxt[i].text = upgradeStatData.statName[i];
            statDescriptionTxt[i].text = upgradeStatData.statDescription[i];
        }
    }

    private void Update()
    {
        spTxt.text = $"SP {GameManager.Instance.sp}";
        for (int i = 0; i < upgradeStatData.statLv.Length; i++)
        {
            statLvTxt[i].text = $"Lv.{upgradeStatData.statLv[i]}";
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    
    public void UpgradeAtk()
    {
        if(GameManager.Instance.sp > 0)
        {
            Time.timeScale = 1.0f;
            GameManager.Instance.sp--;
            upgradeStatData.statLv[0]++;
            Time.timeScale = 0f;
        }
    }

    public void UpgradeMS()
    {
        if (GameManager.Instance.sp > 0)
        {
            Time.timeScale = 1.0f;
            GameManager.Instance.sp--;
            upgradeStatData.statLv[1]++;
            Time.timeScale = 0f;
        }
    }

    public void UpgradeAS()
    {
        if (GameManager.Instance.sp > 0)
        {
            Time.timeScale = 1.0f;
            GameManager.Instance.sp--;
            upgradeStatData.statLv[2]++;
            Time.timeScale = 0f;
        }
    }

    public void UpgradeLuck()
    {
        if (GameManager.Instance.sp > 0)
        {
            Time.timeScale = 1.0f;
            GameManager.Instance.sp--;
            upgradeStatData.statLv[3]++;
            Time.timeScale = 0f;
        }
    }
    
}
