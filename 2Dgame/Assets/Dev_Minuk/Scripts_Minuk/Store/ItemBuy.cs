using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuy : MonoBehaviour
{
    public ItemData itemData;

    public void OnBuyButton()
    {
        if (itemData.itemprice[UIStore.instance.curIndex] < 600/*소지금액*/)
        {
            // 소지금액에서 itemData.itemprice[UIStore.instance.curIndex] 빼주기
            if (itemData.itemstack[UIStore.instance.curIndex] < 3)
            itemData.itemstack[UIStore.instance.curIndex]++;
        }
        UIStore.instance.SetStotore();
    }    
}
