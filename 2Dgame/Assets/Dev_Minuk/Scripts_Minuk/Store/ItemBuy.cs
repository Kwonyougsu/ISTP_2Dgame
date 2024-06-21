using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuy : MonoBehaviour
{
    public ItemData itemData;
    private void Awake()
    {
        itemData = GameManager.Instance.itemData;
    }
    public void OnBuyButton()
    {
        if(UIStore.instance.curIndex != null)
        {
            if (itemData.itemprice[(int)UIStore.instance.curIndex] <= GameManager.Instance.playerGold && itemData.itemstack[(int)UIStore.instance.curIndex] < 3)
            {
                GameManager.Instance.playerGold -= itemData.itemprice[(int)UIStore.instance.curIndex];
                itemData.itemstack[(int)UIStore.instance.curIndex]++;
            }
        }
        UIStore.instance.SetStore();
    }
}
