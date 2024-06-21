using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image ExpBar;
    public TextMeshProUGUI LvTxt;
    public TextMeshProUGUI stageGoldTxt;
    public Transform exp;
    public Transform gold;

    private void Awake()
    {
        exp = this.transform.GetChild(0).transform;
        gold = this.transform.GetChild(1).transform;
        ExpBar = exp.GetChild(1).GetComponent<Image>();
        LvTxt = exp.GetChild(2).GetComponent<TextMeshProUGUI>();
        stageGoldTxt = gold.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ExpBar.fillAmount = GetPercentage();
        LvTxt.text = $"Lv : {GameManager.Instance.Lv}";
        stageGoldTxt.text = $"{GameManager.Instance.stageGold} G";
    }

    private float GetPercentage()
    {
        return GameManager.Instance.curExp / GameManager.Instance.maxExp;
    }
}
