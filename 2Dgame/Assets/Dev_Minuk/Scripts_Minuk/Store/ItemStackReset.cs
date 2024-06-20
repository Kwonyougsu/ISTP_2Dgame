using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStackReset : MonoBehaviour
{
    public ItemData itemData;

    public void OnResetStacks()
    {
        for(int i = 0; i < itemData.itemstack.Length; i++)
        {
            // 플레이어 소지 골드 += (itemData.itemstack[i] * itemData.itemprice[i]);
            itemData.itemstack[i] = 0;
        }
        UIStore.instance.SetStore();
    }
}
