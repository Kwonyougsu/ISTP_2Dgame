using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuy : MonoBehaviour
{
    public ItemData itemData;
    //public PlayerStatsHandler playerStatsHandler;

    public void OnBuyButton()
    {
        if (itemData.itemprice[UIStore.instance.curIndex] < 600/*소지금액*/)
        {
            // 소지금액에서 itemData.itemprice[UIStore.instance.curIndex] 빼주기
            if (itemData.itemstack[UIStore.instance.curIndex] < 3)
            itemData.itemstack[UIStore.instance.curIndex]++;
          //ApplyItemStats(itemData.itemstack[UIStore.instance.curIndex]);
        }
        UIStore.instance.SetStotore();
    }    
//    private void ApplyItemStats(int itemIndex)
//    {
//        PlayerStats itemStats = new PlayerStats();

//       // itemIndex에 따라 증가시킬 스탯을 설정
//        switch (itemIndex)
//        {
//            case 0: // AttackPowerUp
//                itemStats.statsChangeType = StatsChangeType.Add;
//                itemStats.attackSO = new AttackSO { power = 5 };
//break;
//            case 1: // MoveSpeedUp
//    itemStats.statsChangeType = StatsChangeType.Add;
//    itemStats.speed = 3f;
//    break;
//case 2: // HPMaxUp
//    itemStats.statsChangeType = StatsChangeType.Add;
//    itemStats.maxHealth = 10;
//    break;
//case 3: // BulletUp
//    itemStats.statsChangeType = StatsChangeType.Add;
//    itemStats.attackSO = new AttackSO { speed = 0.1f };
//    break;
//}

//        playerStatsHandler.AddStatModifier(itemStats);
//    }

}
